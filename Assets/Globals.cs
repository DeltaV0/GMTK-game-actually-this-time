using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public Enemy[] enemies;

    public static Globals globals;
    // Start is called before the first frame update
    void Start()
    {
        globals = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
