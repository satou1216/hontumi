using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimator : MonoBehaviour
{
    SoundManager audio2;

    Animator animator;
    Vector3 position;
    Vector3 screenToWorldPointPosition;
    Animator cursor;
    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio2 = GameObject.Find("MainCamer").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        attack = animator.GetBool("attack");
        cursor = GameObject.Find("Cursor").GetComponent<Animator>();
        animator.ResetTrigger("hit");
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("3");
            var length = Vector3.Distance(transform.position,screenToWorldPointPosition);
            if (length < 0.5f)
            {
                Debug.Log(attack);


                if (attack == false && ModeManager.MainMode == false)
                {
                    Debug.Log("1");

                    animator.SetTrigger("hit");
                    audio2.sePlay("birdHit");
                    Invoke("destroy", 1.5f);
                }else
                {
                    Debug.Log("0");
                    
                }
                
                
            }
            
            
        }

        //攻撃モードデバッグ用

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
}
