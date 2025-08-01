using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    //public bool active;

    //public GameObject ClickableText1;
    //public GameObject ClickableText2;

    public UnityEvent[] clickActions;
    public GameObject[] clickableTexts;
    private int currentClick = 0;

    public AudioSource aud;

    // Update is called once per frame
    void Update()
    {
        //check distance
        if (Vector3.Distance(transform.position, Movement.player.transform.position) < 1){
            if(clickableTexts.Length > currentClick)
            {
                //activate current text
                clickableTexts[currentClick].SetActive(true);
            }
            if(Input.GetKeyDown("e")){
                aud.Play();
                //if E pressed, toggle
                if (clickActions.Length > 0)
                {
                    clickableTexts[currentClick].SetActive(false);
                    clickActions[currentClick].Invoke();
                    currentClick++;
                    if (currentClick >= clickActions.Length)
                    {
                        currentClick = 0;
                    }
                    clickableTexts[currentClick].SetActive(true);
                }
            }
        } else {
            //get rid of the text if too far away
            foreach(GameObject obj in clickableTexts)
            {
                obj.SetActive(false);
            }
        }
    }
    
}
