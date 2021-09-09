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
            //スクリーンから見たマウスの座標を得る
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //コライダーを持つオブジェクト＝クリックされた場所の座標
            Collider2D collider = Physics2D.OverlapPoint(tapPoint);

            //コライダーが取得出来た時だけ処理する
            if (collider != null)
            {
                //このwhiteはコライダーのGameObjectとしての値を取得
                this.enemy = collider.transform.gameObject;
                
                Destroy(this.enemy,0.5f);
                
            }
        }

    }

}
