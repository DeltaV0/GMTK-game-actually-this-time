using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement player;

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

    private void Awake()
    {
        fireForce = 5;
        innacuracy = 1;
        player = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Reset(){
        transform.position = spawnpoint.position;
    }
    // Update is called once per frame
    void Update()
    {
 
        float moveX = Input.GetAxisRaw ("Horizontal");
		float moveY = Input.GetAxisRaw ("Vertical");
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		moveDir = new Vector2 (moveX, moveY).normalized;
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //body.velocity = input.normalized * speed;
        if(Input.GetMouseButton(0) && reloadTime <= 0){
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
		body.rotation = aimAngle;

        body.AddForce(moveDir * speed, ForceMode2D.Impulse);
        
       /* if(timer > 0){
            bang.SetPosition (1, hitSpot);
            timer--;
        }*/
        if(reloadTime > 0){
            reloadTime--;
        }
        
    }
}
