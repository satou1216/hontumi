using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball: MonoBehaviour
{
    
    Vector3 position;
    Vector3 screenToWorldPointPosition;
    Animator cursor;
    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        cursor = GameObject.Find("Cursor").GetComponent<Animator>();

        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("3");
            var length = Vector3.Distance(transform.position, screenToWorldPointPosition);
            if (length < 0.5f)
            {
                Debug.Log(attack);


                if (attack == false && ModeManager.MainMode == false)
                {
                    Debug.Log("1");


                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("0");

                }


            }


        }

        /* //攻撃モードデバッグ用

         if (Input.GetKeyDown(KeyCode.O))
         {
             animator.SetBool("attack", true);
             cursor.SetBool("attack", true);
         }

         if (Input.GetKeyDown(KeyCode.P))
         {
             animator.SetBool("attack", false);
             cursor.SetBool("attack", false);
         }

     }

     void destroy()
     {
         Destroy(gameObject);
         Debug.Log("3");
     }

     public void AttackModeOn() //攻撃モードをオンにしたときにつけなきゃいけない処理
     {
         animator.SetBool("attack", true);
         cursor.SetBool("attack", true);
     }

     public void AttackModeOff() //攻撃モードをオフにしたときにつけなきゃいけない処理
     {
         animator.SetBool("attack", false);
         cursor.SetBool("attack", false);
     }
        */
    }
}
