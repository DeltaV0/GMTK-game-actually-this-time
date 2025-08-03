using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class AlertTrap : MonoBehaviour
{
    public Transform emitter1, emitter2;
    private LineRenderer lr;
    private EdgeCollider2D edge;
    public List<Enemy> enemies = new List<Enemy>();

    public LayerMask triggerMask;
    private AudioSource alertSound;
    private float active = -1;

    public bool on;


    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.125f;
        lr.endWidth = 0.125f;
        alertSound = GetComponent<AudioSource>();
        edge = GetComponent<EdgeCollider2D>();
        edge.isTrigger = true;
        edge.edgeRadius = 0.125f;
    }
    public void Activate(){
        on = true;
    } 

    public void Deactivate(){
        on = false;
    }
    void FixedUpdate()
    {
        if(on){
        lr.positionCount = 2;
        lr.SetPositions(new Vector3[] {emitter1.localPosition, emitter2.localPosition });
        edge.SetPoints(new List<Vector2> { emitter1.localPosition, emitter2.localPosition });

        if(active >= 0)
        {
            active--;
        }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (active < 0 && (triggerMask & (1 << col.gameObject.layer)) != 0 && on)
        {
            foreach (Enemy enemy in Globals.globals.enemies)
            {
                enemy.chasing = true;
                enemy.lap.seenpos = (emitter1.position + emitter2.position) / 2;
            }
            active = 25;
            alertSound.Play();
        }
    }
}
