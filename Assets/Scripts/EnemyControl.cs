using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed=1;
    bool vertical;
    //public float changeTime = 3.0f;

    new Rigidbody2D rigidbody2D;
    public int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (!vertical)
        { 
            //â°à⁄ìÆ
            position.x = position.x + Time.deltaTime * speed * direction; 
        }
        rigidbody2D.MovePosition(position);

    }
    //ìGÇÃâÊñ äOè¡ãé
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
