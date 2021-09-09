using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CameraControll : MonoBehaviour
{
    // WASD：前後左右の移動
    // QE：上昇・降下
    // 右ドラッグ：カメラの回転
    // 左ドラッグ：前後左右の移動
    // スペース：カメラ操作の有効・無効の切り替え
    // P：回転を実行時の状態に初期化する

    //カメラの移動量
    [SerializeField, Range(0.1f, 10.0f)]
    private float _positionStep = 2.0f;

    //マウス感度
    [SerializeField, Range(30.0f, 150.0f)]
    private float _mouseSensitive = 90.0f;

    //ホイール感度
    [SerializeField, Range(0.10f, 10.0f)]
    private float zoomSpeed = 1.0f;

    [SerializeField, Range(0.10f, 30.0f)]
    private float cameraScroll = 1.0f;

    //カメラのtransform  
    private Transform _camTransform;
    //マウスの始点 
    private Vector3 _startMousePos;
    //カメラ回転の始点情報
    private Vector3 _presentCamRotation;
    private Vector3 _presentCamPos;
    //初期状態 Rotation
    private Quaternion _initialCamRotation;
    //UIメッセージの表示
    private bool _uiMessageActiv;

    private Camera _camera;

    //タワーの高さ
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
        //初期回転の保存
        //_initialCamRotation = this.gameObject.transform.rotation;
    }

    void Update()
    {

        //CamControlIsActive(); //カメラ操作の有効無効

        
            //ResetCameraRotation(); //回転角度のみリセット
            //CameraRotationMouseControl(); //カメラの回転 マウス
            CameraSlideMouseControl(); //カメラの縦横移動 マウス
            CameraZoom();//カメラのズーム マウス
            scrollbarMove();//スクロールバーの操作
            //CameraPositionKeyControl(); //カメラのローカル移動 キー
        
    }

    //カメラのズーム　マウス
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

    //カメラの移動 マウス
    private void CameraSlideMouseControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _startMousePos = Input.mousePosition;
            _presentCamPos = _camTransform.position;
        }

        if (Input.GetMouseButton(1))
        {
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
           // float x = (_startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (_startMousePos.y - Input.mousePosition.y) / Screen.height;

            //x = x * _positionStep;
            y = y * _positionStep;

            velocity = _camTransform.rotation * new Vector3(0, y, 0);
            velocity += _presentCamPos;
            _camTransform.position = velocity;
        }
    }

    //スクロールバーの操作
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