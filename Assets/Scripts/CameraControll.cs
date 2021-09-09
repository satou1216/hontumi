using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CameraControll : MonoBehaviour
{
    // WASD�F�O�㍶�E�̈ړ�
    // QE�F�㏸�E�~��
    // �E�h���b�O�F�J�����̉�]
    // ���h���b�O�F�O�㍶�E�̈ړ�
    // �X�y�[�X�F�J��������̗L���E�����̐؂�ւ�
    // P�F��]�����s���̏�Ԃɏ���������

    //�J�����̈ړ���
    [SerializeField, Range(0.1f, 10.0f)]
    private float _positionStep = 2.0f;

    //�}�E�X���x
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    //�z�C�[�����x
    [SerializeField, Range(0.10f, 10.0f)]
    private float zoomSpeed = 1.0f;

    [SerializeField, Range(0.10f, 30.0f)]
    private float cameraScroll = 1.0f;

    //�J������transform  
    private Transform _camTransform;
    //�}�E�X�̎n�_ 
    private Vector3 _startMousePos;
    //�J������]�̎n�_���
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;
    //������� Rotation
    private Quaternion _initialCamRotation;
    //UI���b�Z�[�W�̕\��
    private bool _uiMessageActiv;

    private Camera _camera;

    //�^���[�̍���
    [SerializeField]
    private float highest_tower;

    [SerializeField]
    private Scrollbar seekbar;
    GameObject scrollbar;

    private Vector3 velocity;
    public bool checkscroll;

    void Start()
    {
        _camTransform = this.gameObject.transform;

        _camera = GetComponent<Camera>();
        //scrollbar = GetComponent<Scrollbar>();
        //������]�̕ۑ�
        //_initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update()
    {

        //CamControlIsActive(); //�J��������̗L������

        
            //ResetCameraRotation(); //��]�p�x�̂݃��Z�b�g
            //CameraRotationMouseControl(); //�J�����̉�] �}�E�X
            CameraSlideMouseControl(); //�J�����̏c���ړ� �}�E�X
            CameraZoom();//�J�����̃Y�[�� �}�E�X
            scrollbarMove();//�X�N���[���o�[�̑���
            //CameraPositionKeyControl(); //�J�����̃��[�J���ړ� �L�[
        
    }

    //�J�����̃Y�[���@�}�E�X
    void CameraZoom()
    {
        float camerasize = 0;
        velocity  = _camTransform.position;
        var scroll = Input.mouseScrollDelta.y;
        cameraScroll = _camera.orthographicSize * scroll * zoomSpeed / 100;
        /*
        float camerapoint = (_camera.orthographicSize + cameraSize * 100) / _camera.orthographicSize;
        Debug.Log(scroll);

        if (scroll > 0)
        {
            float posy = Input.mousePosition.y - Screen.height;
            _camTransform.position = new Vector3(0,posy / camerapoint,0);
        }
        else if(scroll < 0)
        {
            float posy = Input.mousePosition.y - Screen.height;
            _camTransform.position = new Vector3(0, _camTransform.position.y + posy * camerapoint/1080, -10);
        }
        */
        camerasize = _camera.orthographicSize - cameraScroll;
        camerasize = Mathf.Clamp(camerasize, 5f, highest_tower/2 + 5);
        _camera.orthographicSize = camerasize;

        float ize = camerasize;
        velocity.y = Mathf.Clamp(velocity.y, -5 + ize, highest_tower - ize + 5);
        _camTransform.position = velocity;
    }

    //�J�����̈ړ� �}�E�X
    private void CameraSlideMouseControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _startMousePos = Input.mousePosition;
            _presentCamPos = _camTransform.position;
        }

        if (Input.GetMouseButton(1))
        {
            //(�ړ��J�n���W - �}�E�X�̌��ݍ��W) / �𑜓x �Ő��K��
           // float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            //x = x * _positionStep;
            y = y * _positionStep;

            velocity = _camTransform.rotation * new Vector3(0, y, 0);
            velocity += _presentCamPos;
            _camTransform.position = velocity;
        }
    }

    //�X�N���[���o�[�̑���
    void scrollbarMove()
    {
        
        if (checkscroll)
        {
            _camTransform.position = new Vector3(0, seekbar.value * highest_tower, -10);
            _camTransform.position = velocity;
        }
        else
        {
            if(highest_tower > 1)
            {
                seekbar.size = 1 / (1 + (highest_tower/2 + 5 - _camera.orthographicSize));
                seekbar.value = (0.01f + (_camTransform.position.y + 5 - _camera.orthographicSize)) / ( 0.01f + (highest_tower - _camera.orthographicSize * 2 + 10));
            }
            else
            {
                seekbar.size = 1;
                seekbar.value = 0;
            }
        }
    }
    
}