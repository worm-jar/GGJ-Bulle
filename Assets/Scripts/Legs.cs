using UnityEngine;

public class Legs : PlayerCharacter2D
{
    void Update()
    {
        _animator.SetBool("isFalling", _rigidbody.velocity.y < 0);
    }
}
