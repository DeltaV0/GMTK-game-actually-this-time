using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;

    public UnityEngine.AI.NavMeshAgent agent;

    public SpriteRenderer spr;

    public bool disabled;

    public float moveSpeed;

    public bool seePlayer;

    public LookAtPlayer lap;

    public int movementupdatetimer;

    public int sel;

    public Transform[] PatrolPoints;

    public bool chasing;

    public int shoottimer;

    public GameObject bulletPrefab;

    public float innacuracy;
    
    public float fireForce;
    
    public AudioSource shootsound;

    void OnEnable(){
        disabled = false;
        sel = 0;
        chasing = false;
        movementupdatetimer = 100;
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        agent.updatePosition = true;
    }
    void Start()
    {
        Globals.globals.enemies.Add(this);
    }

    void OnDestroy()
    {
        Globals.globals.enemies.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        seePlayer = lap.seePlayer;
        //set this var for ease of use ig
        transform.position = new Vector3(transform.position.x, transform.position.y, 0); 
        //make sure player is aligned in case it isnt somehow
        if(shoottimer <= 0 && seePlayer && !Globals.globals.reloading && !disabled){
            //shoot at player if can see player and no timer
            shootsound.Play();
            shoottimer = 100;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector2 aimDirection = new Vector2(transform.position.x, transform.position.y) - new Vector2(Movement.player.transform.position.x, Movement.player.transform.position.y);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));

            bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;

            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce), ForceMode2D.Impulse);

        }
    }

    private void FixedUpdate(){
        //chaos
        if(shoottimer > 0 && seePlayer){
            shoottimer--;
        }
        if(!Globals.globals.reloading && !disabled){
        //AI movement logic
        if(movementupdatetimer >= 0 && !chasing){

            if(agent.remainingDistance <= 0.5){
            movementupdatetimer--;
            //only lower movetimer if the enemy is almost at their destination
            }
            
        } else {
            //i give up commenting lol
            if(!chasing){
                movementupdatetimer = 50;
                if(sel < PatrolPoints.Length - 1){
                    sel++;
                } else {
                    sel = 0;
                }
                agent.SetDestination(PatrolPoints[sel].position);
            }
        }
        if(seePlayer){
            chasing = true;
            agent.SetDestination(Movement.player.transform.position);
            //agent.isStopped = false;

            //rb.AddForce((transform.position - agent.nextPosition) * (-1 * moveSpeed));
        //agent.Warp(transform.position);
        } else {
            if(chasing){
            agent.SetDestination(lap.seenpos);
            if(agent.remainingDistance <= 0.5){
                chasing = false;
                movementupdatetimer = 500;
            }
            }
            //agent.isStopped = true;
            //agent.velocity = new Vector3(0, 0, 0);
        }
    } else {
        agent.isStopped = true;
        agent.velocity = new Vector3(0, 0, 0);
    }
    }
}
