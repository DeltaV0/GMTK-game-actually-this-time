using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public Enemy[] enemies;

    public static Globals globals;

    public bool reloading;

    public Transform[] points;

    public int level;

    public GameObject nextLevelAnim;
    // Start is called before the first frame update

    private void Awake()
    {
        level = PlayerPrefs.GetInt("Lvl");
        reloading = false;
        
    }

    public void nextlevel(){

        PlayerPrefs.SetInt("Lvl", Mathf.Min(PlayerPrefs.GetInt("Lvl") + 1, points.Length - 1));
        level = PlayerPrefs.GetInt("Lvl");
    }

    public void prevlevel(){
        
        PlayerPrefs.SetInt("Lvl", Mathf.Max(PlayerPrefs.GetInt("Lvl") - 1, 0));
        level = PlayerPrefs.GetInt("Lvl");
        Movement.player.transform.position = points[level].position;
    }
    void Start()
    {
        globals = this;
        Movement.player.transform.position = points[level].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("l")){
            prevlevel();
        }
        else if (Input.GetKeyDown("n"))
        {
            nextlevel();
        }
    }
}
