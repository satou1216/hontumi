using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed=1;
    bool vertical;
    //public float changeTime = 3.0f;

    Rigidbody2D rig2D;
    public int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 position = rig2D.position;

        if (!vertical)
        { 
            //â°à⁄ìÆ
            position.x = position.x + Time.deltaTime * speed * direction; 
        }
        rig2D.MovePosition(position);

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
