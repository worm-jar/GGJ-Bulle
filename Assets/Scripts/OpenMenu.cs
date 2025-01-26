using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    public bool on = false;
    public Transform Tile;
    public Transform Tile0;
    // Start is called before the first frame update
    void Awake()
    {
        Tile = this.transform.Find("Panel");
        Tile0 = this.transform.Find("Panel0");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (on == false)
            {
                Tile.gameObject.SetActive(true);
                Time.timeScale = 0;
                on = true;
            }
            else if (on == true)
            {
                Tile.gameObject.SetActive(false);
                Time.timeScale = 1;
                on = false;
            }
        }
        if (PlayerInfo.health <= 0)
        {
            Tile0.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
