using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    bool vertical;
    //public float changeTime = 3.0f;

    new Rigidbody2D rigidbody2D;
    float timer;
    public int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //timer = changeTime;

    }

    void Update()
    {

        //timer -= Time.deltaTime;

        if (timer < 0)
        {
            //”½“]
            direction = -direction;
            //timer = changeTime;
        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (!vertical)
        { 
            //‰¡ˆÚ“®
            position.x = position.x + Time.deltaTime * speed * direction; 
        }
        rigidbody2D.MovePosition(position);
    }
    public void stop()
    {
        speed = 0;
    }
}
