using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Button : MonoBehaviour
{
    //public bool active;

    //public GameObject ClickableText1;
    //public GameObject ClickableText2;

    public UnityEvent[] clickActions;
    public GameObject[] clickableTexts;
    private int currentClick = 0;

    public AudioSource aud;

    public bool winbutton;

    public TMP_Text text;

    IEnumerator Countdown(){
        text.text = "5";
        yield return new WaitForSeconds(1f);
        text.text = "4";
        yield return new WaitForSeconds(1f);
        text.text = "3";
        yield return new WaitForSeconds(1f);
        text.text = "2";
        yield return new WaitForSeconds(1f);
        text.text = "1";
        yield return new WaitForSeconds(1f);
        text.text = "";
    }

    void toggle(){
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
                if(!winbutton){
                    toggle();
                } else {
                    Invoke("toggle", 5f);
                    text.text = "";
                    StartCoroutine(Countdown());
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
