using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public GameObject Canv0, Canv1;

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
        Application.Quit();
    }
    public void PlayScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");  
    }
    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleMenu");
        Destroy(this.gameObject);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Title()
    {
        SceneManager.LoadScene("TitleMenu");
        Destroy(this.gameObject);
    }
}
