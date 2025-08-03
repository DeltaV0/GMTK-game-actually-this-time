using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public static Movement player;

    public Image HealthCircle;
    public TMP_Text text;

    public Transform PlayerPos;

    public GameObject bulletPrefab;

    [SerializeField]
    public float speed = 3;
    public Rigidbody2D body;

    Vector2 moveDir;

    public LineRenderer bang;

    Vector2 mousePos;
    
    private int reloadTime;

    private Vector3 hitSpot;

    private int timer;

    public float innacuracy;
    
    public float fireForce;

    public Transform spawnpoint;

    public int lives;// (customizable!!)

    public ParticleSystem[] parts;

    public Animator[] animator;

    public AudioSource[] aud;

    public GameObject deathanim;

    public GameObject dieparts;

    private void Awake()
    {
        player = this;
        //Globals.globals.reloading = false;
        fireForce = 5;
        innacuracy = 1;
        
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        
        Debug.Log(Time.timeScale );
    }

    public void Reset(){
        body.velocity = new Vector2(0, 0);
        lives--;
        if(lives > 0){
        GameObject bullet = (GameObject)Instantiate(dieparts, transform.position, transform.rotation);
        aud[0].Play();
        
        animator[0].SetTrigger("respawn");
        transform.position = Globals.globals.points[Globals.globals.level].position;
        }
        
    }
    public void reload(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        HealthCircle.fillAmount = (float)((float)lives/ 3f);
        text.text = lives + "";
        if(Input.GetKeyDown("left shift")){
            body.velocity = new Vector2(0, 0);
            lives--;
            if(lives > 0){
            GameObject bullet = (GameObject)Instantiate(dieparts, transform.position, transform.rotation);
            aud[0].Play();
        
            animator[0].SetTrigger("respawn");
            transform.position = Globals.globals.points[Globals.globals.level].position;
        }
        }
        if(Input.GetKeyDown("tab")){
            aud[3].Play();
            Globals.globals.points[Globals.globals.level].position = transform.position;
        }
        /*if(Input.GetKeyDown("p")){
            aud[2].Stop();
            deathanim.SetActive(true);
            Debug.Log(Time.timeScale );
            Globals.globals.reloading = true;
            //Time.fixedDeltaTime = 10000f;
            lives--;
           // Time.timeScale = 1f;
            Invoke("reload", 6.5f);
            //reload of out of lives (or loops ig)
        }*/

        if(lives == 0){
            aud[2].Stop();
            deathanim.SetActive(true);
            Debug.Log(Time.timeScale );
            Globals.globals.reloading = true;
            //Time.fixedDeltaTime = 10000f;
            lives--;
           // Time.timeScale = 1f;
            Invoke("reload", 6f);
            //reload of out of lives (or loops ig)
            
        }

        if(Input.GetKeyDown("space")){
            Vector2 aimDirection = mousePos - body.position;
            body.AddForce(aimDirection * 10, ForceMode2D.Impulse);
            parts[0].Play();
        }
        float moveX = Input.GetAxisRaw ("Horizontal");
		float moveY = Input.GetAxisRaw ("Vertical");
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		moveDir = new Vector2 (moveX, moveY).normalized;
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //body.velocity = input.normalized * speed;
        if(Input.GetMouseButton(0) && reloadTime <= 0 && !Globals.globals.reloading){
            aud[1].Play();
            //  two seconds
            reloadTime = 100;
            //timer = 4;

            GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);

            Vector2 aimDirection = new Vector2(transform.position.x, transform.position.y) - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f + Random.Range(-1f * (innacuracy * 0.5f), (innacuracy * 0.5f));

            bullet.GetComponent<Rigidbody2D>().rotation = aimAngle;


            bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce, Mathf.Sin((bullet.GetComponent<Rigidbody2D>().rotation + 90f) * Mathf.Deg2Rad) * fireForce), ForceMode2D.Impulse);
            

			/*int lm = LayerMask.GetMask("Enemy", "Walls");

			//lm = ~lm;
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 500f, lm);
			if(hit){
                //Debug.Log(hit.point);
                hitSpot = new Vector3(hit.point.x, hit.point.y, 0);
                for(int i = 0; i < Globals.globals.enemies.Length; i++){
                    int lm2 = LayerMask.GetMask("Enemy", "Walls");
                    Vector2 pointBetween = Vector2.Lerp(transform.position, hit.point, 0.95f);
			        RaycastHit2D hit2 = Physics2D.Linecast(pointBetween, Globals.globals.enemies[i].transform.position, lm2);

                    if(hit2 && hit2.transform.gameObject.layer == 3){
                        Globals.globals.enemies[i].chasing = true;
                        Globals.globals.enemies[i].lap.seenpos = hitSpot;
                    }
                }
				//bang.SetPosition (1, new Vector3(hit.point.x, hit.point.y, 0));
			} else {
				bang.SetPosition (1, transform.position);
			}
			
			bang.SetPosition (0, transform.position);
		} else {
            if(timer <= 0){
			bang.SetPosition (1, transform.position);
            bang.SetPosition (0, transform.position);
            }
			
		*/}
    }

    void FixedUpdate(){
        Vector2 aimDirection = mousePos - body.position;
		
		float aimAngle = Mathf.Atan2 (aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
		

        if(!Globals.globals.reloading){
        body.rotation = aimAngle;
        body.AddForce(moveDir * speed, ForceMode2D.Impulse);
        }
       /* if(timer > 0){
            bang.SetPosition (1, hitSpot);
            timer--;
        }*/
        if(reloadTime > 0){
            //  called every 0.02 seconds (50 times per second)
            reloadTime--;
        }
        
    }
}
