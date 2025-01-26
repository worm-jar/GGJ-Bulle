using Unity.VisualScripting;
using UnityEngine;

/**
 *  The [RequireComponent] attribute tells Unity that this component actually "requires" another one. So when this component is added
 *  to a GameObject, Unity will automatically add all the required components if they are not already set on the object. Plus, Unity won't
 *  allow one of these required components from the GameObject while another component require them.
 *  As an example, when you add this PlayerCharacter2D component to an object in the scene, Unity will also add Rigidbody2D and Animator
 *  components. And if you try to remove Rigidbody2D, Unity will disallow it, and display a popup saying that another component depends on
 *  it. To remore the Rigidbody2D or Animator, you must first remove the PlayerCharacter2D component, because there's no more component
 *  that require them.
 */
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerCharacter2D : MonoBehaviour
{

    [Tooltip("The force to apply to make this character move.")]
    public float movementAcceleration = 20f;

    [Tooltip("The maximum speed (in units/s) of this character along the X axis.")]
    public float maxMovementSpeed = 4f;

    [Tooltip("The upward force applied to this character when pressing the Jump input.")]
    public float jumpForce = 16f;

    [Tooltip("The upward force that slows the fall of your character when pressing the Jetpack input")]
    public float JetpackForce = 0.5f;

    private bool IsGrounded;
    public Transform FeetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    public float GlidingSpeed = 1;
    private float _InitialGravityScale;
    private bool IsGliding;
    private bool IsDeactivating;
    private bool IsActivating;
    public SpriteRenderer headS, jetpackS, legsS;

    private float JumpTimeCounter;
    public float JumpTime;
    private bool IsJumping;


    public AudioSource _aud;
    public AudioClip _clip;
    /// <summary>
    /// The component used to make this character move and jump.
    /// </summary>
    private Rigidbody2D _rigidbody = null;

    /// <summary>
    /// The component used to play animations on this character.
    /// </summary>
    private Animator _animator = null;

    /// <summary>
    /// The component used to display the character on screen.
    /// </summary>
    private SpriteRenderer _spriteRenderer = null;

    /// <summary>
    /// Called when the scene is loaded, before Start().<br/>
    /// We use this to initialize this component. Here, we use this function to get the reference to the Rigidbody2D and Animator
    /// components. And there's no need to check if they exist or not: since we use [RequireComponent] on this class, they're guaranteed to
    /// be attached to the object.
    /// </summary>
    private void Awake()
    {
        // Note that the variables to store the references to these components are private: there's no need to assign them manually in the
        // editor, because we can get them automatically here.
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _InitialGravityScale = _rigidbody.gravityScale;
    }

    /// <summary>
    /// Called every frame.
    /// </summary>
    private void Update()
    {
        UpdateMovement();
        UpdateJump();
        UpdateJetpack();
        ClampVelocity();

        // Flip sprite based on movement direction
        _spriteRenderer.flipX = _rigidbody.velocity.x < 0;
        // Animation state updates
        if (IsGrounded && !_animator.GetBool("IsJumping") && !_animator.GetBool("isFalling"))
        {
            _animator.SetFloat("xVelocity", Mathf.Abs(_rigidbody.velocity.x));
        }
        else
        {
            _animator.SetFloat("xVelocity", 0); // Ensures Walk animation won't play while jumping or falling
        }

        _animator.SetBool("isFalling", _rigidbody.velocity.y < 0 && !IsGrounded);

        // Update jumping/falling/gliding animation logic
        if (_rigidbody.velocity.y > 0 && !IsGrounded)
        {
            _animator.SetBool("IsJumping", true);
            _animator.SetBool("isFalling", false);
        }
        else if (_rigidbody.velocity.y < 0 && !IsGrounded)
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("isFalling", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("isFalling", false);
        }
    }


    /// <summary>
    /// Checks for movement inputs (arrow keys), and add acceleration force to make the character move accordingly.
    /// </summary>
    private void UpdateMovement()
    {
        float xMovement = 0f;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            xMovement += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            xMovement += -1;
        }

        // If the character is not moving
        if (xMovement == 0)
        {
            // Stop its movement, but only along the X axis
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }
        else
        {
            /**
             *  Instead of "teleporting" the character by directly setting its position, we use physics to make it move by changing its
             *  velocity:
             *  - Vector2.right is a shortcut to write Vector2(1, 0). We get a vector with a length of 1 toward the right.
             *  - Let's say that the player is pressing the left arrow. xMovement has a value of -1. Multiplying a vector by a number
             *  multiplies each component (here X and Y) individually. So the velocity to add is for now Vector2(-1, 0).
             *  - movementAcceleration is like the "speed" variable we used in another chapter. But because we're using physics here, we
             *  will talk about an "acceleration" to add. If this variable has a value of 20, we multiply the force to add by 20, and we
             *  get a vector Vector2(-20, 0).
             *  - Time.deltaTime is the time elapsed since the previous frame, in seconds. Multiplying by this value can be understood as
             *  "by seconds". So, finally, we are adding a force of -20 along the X axis per second.
             *  
             *  The velocity is applied by the Rigidbody2D component. Because of physics, the component will take account of friction when
             *  it collides with other objects. So if you can't see the character move when pressing the arrow keys, it may be because the
             *  movementAcceleration value is not high enough to surpass the friction with the ground and move.
             */
            _rigidbody.velocity += Vector2.right * xMovement * movementAcceleration * Time.deltaTime;
        }
    }

    /// <summary>
    /// Checks for jump input (space), and add an upward force to the character if applicable.
    /// </summary>
    private void UpdateJump()
    {
        IsGrounded = Physics2D.OverlapCircle(FeetPos.position, checkRadius, WhatIsGround);

        // Note that we use GetKeyDown() here to detect if the spacebar has been pressed this frame and this frame only. If we were using
        // GetKey() here, the character would jump every frame!
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _aud.clip = _clip;
            _aud.Play();
            IsJumping = true;
            JumpTimeCounter = JumpTime;
            _rigidbody.velocity = Vector2.up * jumpForce;
            
        }
        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
            if (JumpTimeCounter > 0)
            {
                _rigidbody.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime;
                
            }
            else
            { 
                IsJumping = false;
            }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }
    }

    private void UpdateJetpack()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (_rigidbody.velocity.y <= 0) // Only activate if falling
            {
                if (!IsActivating)
                {
                    IsActivating = true;
                    IsDeactivating = false;
                    _animator.SetTrigger("ActivateJetpack");
                }

                // Start Gliding
                _rigidbody.gravityScale = 0; // No gravity during gliding
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, -JetpackForce); // Control downward movement
                IsGliding = true;
                _animator.SetBool("IsGliding", true);
            }
        }
        else
        {
            if (IsActivating)
            {
                IsActivating = false;
                IsDeactivating = true;
                _animator.SetTrigger("DeactivateJetpack");
            }

            // Restore gravity when not gliding
            if (IsGliding)
            {
                _rigidbody.gravityScale = _InitialGravityScale;
                _animator.SetBool("IsGliding", false);
                IsGliding = false;
            }
        }

        // Ensuring the DeactivateJetpack animation plays properly
        if (IsDeactivating)
        {
            if (_rigidbody.velocity.y >= 0) // Only stop when upwards or at rest
            {
                IsDeactivating = false;
            }
        }
    }

    /// <summary>
    /// Makes sure that the velocity of the character along the X axis doesnt exceed the maximum allowed speed.
    /// </summary>
    private void ClampVelocity()
    {
        Vector2 velocity = _rigidbody.velocity;
        // The Clamp() function will lock a value between a minimum and a maximum
        velocity.x = Mathf.Clamp(velocity.x, -maxMovementSpeed, maxMovementSpeed);
        _rigidbody.velocity = velocity;
    }

}
