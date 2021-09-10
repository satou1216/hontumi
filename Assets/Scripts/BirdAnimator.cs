using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimator : MonoBehaviour
{
    Animator animator;
    Vector3 position;
    Vector3 screenToWorldPointPosition;
    Animator cursor;
    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
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
            
            var length = Vector3.Distance(transform.position,screenToWorldPointPosition);
            if (length < 0.5f)
            {
                //Debug.Log("1");
                if(attack == true && ModeManager.MainMode == false)
                {
                    
                    animator.SetTrigger("hit");
                    Invoke("destroy", 1.5f);
                }else
                {
                    //Debug.Log("0");
                }
                
                
            }
            
            
        }

        //�U�����[�h�f�o�b�O�p

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
    }

    public void AttackModeOn() //�U�����[�h���I���ɂ����Ƃ��ɂ��Ȃ��Ⴂ���Ȃ�����
    {
        animator.SetBool("attack", true);
        cursor.SetBool("attack", true);
    }

    public void AttackModeOff() //�U�����[�h���I�t�ɂ����Ƃ��ɂ��Ȃ��Ⴂ���Ȃ�����
    {
        animator.SetBool("attack", false);
        cursor.SetBool("attack", false);
    }
}
