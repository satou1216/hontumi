using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDelete : MonoBehaviour
{

     EnemyControl EC;
     GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        this.enemy = GameObject.Find("enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            //�X�N���[�����猩���}�E�X�̍��W�𓾂�
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //�R���C�_�[�����I�u�W�F�N�g���N���b�N���ꂽ�ꏊ�̍��W
            Collider2D collider = Physics2D.OverlapPoint(tapPoint);

            //�R���C�_�[���擾�o������������������
            if (collider != null)
            {
                //����white�̓R���C�_�[��GameObject�Ƃ��Ă̒l���擾
                this.enemy = collider.transform.gameObject;
                
                Destroy(this.enemy,0.5f);
                
            }
        }

    }

}
