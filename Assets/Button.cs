using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool active;

    public GameObject ClickableText1;
    public GameObject ClickableText2;

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Movement.player.transform.position) < 1){
            //check distance
            if(Input.GetKeyDown("e")){
                //if E pressed, toggle
                active = !active;
            }
            if(active){
                //if active, activate the door and show the deactivate text instead
                ClickableText1.SetActive(false);
                ClickableText2.SetActive(true);
                door.SetActive(false); 
            } else {
                //if not active, close the door and show activate text
                ClickableText2.SetActive(false);
                ClickableText1.SetActive(true);
                door.SetActive(true);
            }
        } else {
            //get rid of the text if too far away
                ClickableText1.SetActive(false);
                ClickableText2.SetActive(false);
        }
    }
    
}
