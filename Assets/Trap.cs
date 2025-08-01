using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trap : MonoBehaviour
{
    public TMP_Text text;

    public int Cooldown;

    public ParticleSystem part;

    public AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(Cooldown > 0){
        Cooldown--;
        text.text = "X";
        } else{
        text.text = "!";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == 3 && Cooldown <= 0){
            aud.Play();
            part.Play();
            Cooldown = 1000;
            col.gameObject.GetComponent<Enemy>().disabled = true;
            col.gameObject.GetComponent<Enemy>().spr.color = new Color(0.5f, 0.5f, 0.5f);
        }
        if(col.gameObject.name == "Me rn :3" && Cooldown <= 0){
            aud.Play();
            part.Play();
            Cooldown = 1000;
            Movement.player.Reset();
        }
    }


}
