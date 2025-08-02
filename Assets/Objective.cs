using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public string nextlevelname;
    private bool complete = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Me rn :3" && !complete){
            Globals.globals.reloading = true;
            Globals.globals.nextLevelAnim.SetActive(true);
            StartCoroutine(NextLevel());
            Movement.player.aud[2].Pause();
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(7);
        Globals.globals.reloading = false;
        Globals.globals.nextlevel();
        Movement.player.transform.position = Globals.globals.points[Globals.globals.level].position;
        Movement.player.lives = 5;
        Movement.player.aud[2].UnPause();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name); 
        //SceneManager.LoadScene(nextlevelname);
    }
}
