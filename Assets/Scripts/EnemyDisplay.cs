using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    
    public float randamMin;
    public float randamMax;
    public float x;
    public GameObject target;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (target != null)
            {
                //Instantiate( ��������I�u�W�F�N�g,  �ꏊ, ��] );  ��]�͂��̂܂܂Ȃ火
                Instantiate(target, new Vector2(x, Random.Range(randamMin, randamMax)), Quaternion.identity);
            }
        }
    }
}
