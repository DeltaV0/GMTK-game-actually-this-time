using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();

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
        globals = this;
    }

    public void nextlevel(){

        PlayerPrefs.SetInt("Lvl", Mathf.Min(PlayerPrefs.GetInt("Lvl") + 1, points.Length - 1));
        level = PlayerPrefs.GetInt("Lvl");
        Movement.player.transform.position = points[level].position;
    }

    public void prevlevel(){
        
        PlayerPrefs.SetInt("Lvl", Mathf.Max(PlayerPrefs.GetInt("Lvl") - 1, 0));
        level = PlayerPrefs.GetInt("Lvl");
        Movement.player.transform.position = points[level].position;
    }
    void Start()
    {
        Movement.player.transform.position = points[level].position;
    }
}
