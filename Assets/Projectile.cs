using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool done;

    public Rigidbody2D rb;

    public ParticleSystem noiseparts;
    // Start is called before the first frame update
    void Start()
    {
        //done = false;
    }

    private void Awake()
    {
        done = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(rb.velocity.magnitude < 2 && !done){
            done = true;
            noiseparts.Play();
            for(int i = 0; i < Globals.globals.enemies.Length; i++){
                    int lm2 = LayerMask.GetMask("Enemy", "Walls");
                    //Vector2 pointBetween = Vector2.Lerp(transform.position, hit.point, 0.95f);
			        RaycastHit2D hit2 = Physics2D.Linecast(transform.position, Globals.globals.enemies[i].transform.position, lm2);

                    if(hit2 && hit2.transform.gameObject.layer == 3){
                        Globals.globals.enemies[i].chasing = true;
                        Globals.globals.enemies[i].lap.seenpos = transform.position;
                    }
                }
        }
    }
}
