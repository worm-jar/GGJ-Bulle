using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Gone()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
    public void PlayScene()
    {
        Time.timeScale = 1;
        TurnOffSprite.On = false;
        SceneManager.LoadScene("SampleScene");  
    }
    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleMenu");
    }
    public void Credits()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Credits");
    }
    public void Title()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleMenu");
    }
}
