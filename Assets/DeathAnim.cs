using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathAnim : MonoBehaviour
{
    public TMP_Text text;

    public int line;



    public string[] texts;
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(anim());
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator anim(){

        for(int i = 0; i < 4; i++){
            for(int a = 0; a < texts[line].Length; a++){
                text.text = text.text + texts[line][a];
                if(line < 3){
                    yield return new WaitForSeconds(0.05f);
                } else {
                    yield return new WaitForSeconds(0.25f);
                }
            }
            text.text += "\n";
            line++;
            yield return new WaitForSeconds(0.5f);
        }

    }
}
