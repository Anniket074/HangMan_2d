using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{  
    public GameCOntroller gameCOntroller;
    public AudioSource Source;
    public AudioClip click;
    public GameObject Panel;
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Animal()
    {
        Source.clip = click;
        Source.Play();
        // SceneManager.LoadScene("Fruit", LoadSceneMode.Additive);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Fruit()
    {
        Source.clip = click;
        Source.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void Opt()
    {
        gameCOntroller.option = true;
        Debug.Log("Press")
;    }

}

