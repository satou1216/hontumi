using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager; //�T�E���h�}�l�[�W���[

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //���N���b�N
        {
            soundManager.sePlay("resultSE"); //�T�E���h�}�l�[�W���[���g�p���Č��ʉ��Đ�
        }
        if (Input.GetMouseButtonDown(1)) //���N���b�N
        {
            soundManager.bgmPlay("gameMusic"); //�T�E���h�}�l�[�W���[���g�p���Č��ʉ��Đ�
        }

    }
}