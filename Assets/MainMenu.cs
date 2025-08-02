using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject[] gobj;

    public AudioSource aud;

    public void load(){
        aud.Stop();
		Invoke("loadactually", 7f);
        gobj[0].SetActive(true);
	}

    public void newgame(){
        aud.Stop();
        Invoke("newactually", 12f);
        gobj[1].SetActive(true);
	}

    public void loadactually(){
        SceneManager.LoadSceneAsync("game");
    }

    public void newactually(){
        PlayerPrefs.SetInt("Lvl", 0);
		SceneManager.LoadSceneAsync("game");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
