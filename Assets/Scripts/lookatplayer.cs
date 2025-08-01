using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public bool seePlayer;

    public Vector3 seenpos;

    public int seeDelay;

    public bool playerInSight;
    // Start is called before the first frame update
    void Start()
    {
        seenpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(seeDelay > 0){
            seeDelay--;
        }
        Vector2 aimDirection = Movement.player.transform.position - transform.position;
        float aimAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, aimAngle); 
        int lm = LayerMask.GetMask("Player", "Walls");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 500f, lm);
        if(hit && hit.transform.gameObject.name == "Me rn :3"){
            if(!playerInSight){
                seeDelay = 50;
            }
            playerInSight = true;
            if(seeDelay <= 0){
            seePlayer = true;
            seenpos = hit.transform.position;
            }
        } else {
            playerInSight = false;
            seePlayer = false;
        }
        //Debug.Log(transform.gameObject.name);
    }
}
