//�I���W�i���}�E�X�J�[�\�������v���O����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.position = Input.mousePosition;
    }
}
