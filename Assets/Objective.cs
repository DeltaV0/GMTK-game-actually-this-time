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
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextlevelname);
    }
}
