using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 7){
            //if hits wall layer, destroy
            Destroy(gameObject);
        }
        if(col.gameObject.name == "Me rn :3"){
            //if hits player, respawn player and destroy
            Movement.player.Reset();
            Destroy(gameObject);
        }
    }
}
