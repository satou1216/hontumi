using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager; //サウンドマネージャー

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //左クリック
        {
            soundManager.sePlay("resultSE"); //サウンドマネージャーを使用して効果音再生
        }
        if (Input.GetMouseButtonDown(1)) //左クリック
        {
            soundManager.bgmPlay("gameMusic"); //サウンドマネージャーを使用して効果音再生
        }

    }
}