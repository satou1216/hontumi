using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManagerV2 : MonoBehaviour
{
    Animator bird;
    
    Animator animator;

    SoundManager SM;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        SM = GameObject.Find("MainCamer").GetComponent<SoundManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        gameObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("oto!!!");
            SM.sePlay("button1");
        }
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("click", true);
        }
        else
        {
            animator.SetBool("click", false);
        }

        //�U�����[�h�f�o�b�O�p(old)
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

    public void AttackModeOn() //�U�����[�h���I���ɂ����Ƃ��ɂ��Ȃ��Ⴂ���Ȃ�����
    {
        animator.SetBool("attack", true);
        
    }

    public void AttackModeOff() //�U�����[�h���I�t�ɂ����Ƃ��ɂ��Ȃ��Ⴂ���Ȃ�����
    {
        animator.SetBool("attack", false);
        
    }
}
