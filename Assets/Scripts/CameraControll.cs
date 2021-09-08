using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

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

    //�J��������̗L������
    private bool _cameraMoveActive = true;
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
    public float highest_tower;

    void Start()
    {
        _camTransform = this.gameObject.transform;

        _camera = GetComponent<Camera>();

        //������]�̕ۑ�
        //_initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update()
    {

        CamControlIsActive(); //�J��������̗L������

        if (_cameraMoveActive)
        {
            //ResetCameraRotation(); //��]�p�x�̂݃��Z�b�g
            //CameraRotationMouseControl(); //�J�����̉�] �}�E�X
            CameraSlideMouseControl(); //�J�����̏c���ړ� �}�E�X
            CameraZoom();//�J�����̃Y�[�� �}�E�X
            //CameraPositionKeyControl(); //�J�����̃��[�J���ړ� �L�[
        }
    }

    //�J��������̗L������
    public void CamControlIsActive()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cameraMoveActive = !_cameraMoveActive;

            if (_uiMessageActiv == false)
            {
                StartCoroutine(DisplayUiMessage());
            }
            Debug.Log("CamControl : " + _cameraMoveActive);
        }
    }

    //��]��������Ԃɂ���
    private void ResetCameraRotation()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.transform.rotation = _initialCamRotation;
            Debug.Log("Cam Rotate : " + _initialCamRotation.ToString());
        }
    }

    //�J�����̉�] �}�E�X
    private void CameraRotationMouseControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePos = Input.mousePosition;
            _presentCamRotation.x = _camTransform.transform.eulerAngles.x;
            _presentCamRotation.y = _camTransform.transform.eulerAngles.y;
        }

        if (Input.GetMouseButton(0))
        {
            //(�ړ��J�n���W - �}�E�X�̌��ݍ��W) / �𑜓x �Ő��K��
            float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            //��]�J�n�p�x �{ �}�E�X�̕ω��� * �}�E�X���x
            float eulerX = _presentCamRotation.x + y * _mouseSensitive;
            float eulerY = _presentCamRotation.y + x * _mouseSensitive;

            _camTransform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
        }
    }

    //�J�����̃Y�[���@�}�E�X
    void CameraZoom()
    {
        float camerasize = 0;
        Vector3 position = _camTransform.position;
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
        position.y = Mathf.Clamp(position.y, -5 + ize, highest_tower/2);
        _camTransform.position = position;
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

            Vector3 velocity = _camTransform.rotation * new Vector3(0, y, 0);
            velocity = velocity + _presentCamPos;
            _camTransform.position = velocity;
        }
    }

    //�J�����̃��[�J���ړ� �L�[
    private void CameraPositionKeyControl()
    {
        Vector3 campos = _camTransform.position;

        if (Input.GetKey(KeyCode.D)) { campos += _camTransform.right * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.A)) { campos -= _camTransform.right * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.E)) { campos += _camTransform.up * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.Q)) { campos -= _camTransform.up * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.W)) { campos += _camTransform.forward * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.S)) { campos -= _camTransform.forward * Time.deltaTime * _positionStep; }

        _camTransform.position = campos;
    }

    //UI���b�Z�[�W�̕\��
    private IEnumerator DisplayUiMessage()
    {
        _uiMessageActiv = true;
        float time = 0;
        while (time < 2)
        {
            time = time + Time.deltaTime;
            yield return null;
        }
        _uiMessageActiv = false;
    }

    void OnGUI()
    {
        if (_uiMessageActiv == false) { return; }
        GUI.color = Color.black;
        if (_cameraMoveActive == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "�J�������� �L��");
        }

        if (_cameraMoveActive == false)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 30, 100, 20), "�J�������� ����");
        }
    }

}