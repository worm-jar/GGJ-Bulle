using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{

    [SerializeField] public static int health;
    private int fuel;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }
}
