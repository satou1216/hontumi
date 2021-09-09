using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManagerV2 : MonoBehaviour
{
    Animator bird;
    
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        gameObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("click", true);
        }
        else
        {
            animator.SetBool("click", false);
        }

        //攻撃モードデバッグ用(old)
        /*
        if(Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("attack",true);
            bird.SetBool("attack", true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("attack", false);
            bird.SetBool("attack", false);
        }
        */
    }

    public void AttackModeOn() //攻撃モードをオンにしたときにつけなきゃいけない処理
    {
        animator.SetBool("attack", true);
        
    }

    public void AttackModeOff() //攻撃モードをオフにしたときにつけなきゃいけない処理
    {
        animator.SetBool("attack", false);
        
    }
}
