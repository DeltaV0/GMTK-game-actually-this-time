using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMove : MonoBehaviour
{
    public Transform trans;

    private float DT;

    public float movepower;

    public bool maincam;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        DT = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Time.fixedDeltaTime = DT * Time.timeScale;

    }

    private void FixedUpdate()
    {
        //lerp to player position
        if(!Globals.globals.reloading){
		transform.position = Vector3.Lerp(transform.position, Vector3.Lerp(new Vector3(trans.position.x, trans.position.y, transform.position.z), Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.2f * movepower), 0.1f);
        if(maincam){
            if(Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(trans.position.x, trans.position.y)) > 1){
				cam.orthographicSize = Mathf.Clamp(Mathf.Lerp(cam.orthographicSize, Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(trans.position.x, trans.position.y)) + 5, 0.04f), 0f, 7f);
			} else {
				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5f, 0.04f);;
			}
        }
        }
    }
}
