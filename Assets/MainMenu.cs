using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject[] gobj;

    public void load(){
		Invoke("loadactually", 6.5f);
        gobj[0].SetActive(true);
	}

    public void newgame(){
        Invoke("newactually", 11f);
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
