using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    public float While;
    public float randamMin;
    public float randamMax;
    public float x;
    float seconds;
    public GameObject target;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;
        //\•b‚²‚Æ‚É“G¶¬
        if (seconds >= While)
        { 
            if (target != null)
            {
                //“G‚Ì¶¬
                Instantiate(target, new Vector2(x, Random.Range(randamMin, randamMax)), Quaternion.identity);
            }
            //•b”ƒŠƒZƒbƒg
            seconds = 0;
        }
    }

}
