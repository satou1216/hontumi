using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public float bestY = 0;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        /* if (collision.gameObject.tag == "top")
         {
             this.tag = "book";
             Destroy(this.GetComponent <Detection> ());
         }
         */
        if (collision.tag != "Untagged")
        {
            bestY = gameObject.transform.position.y + height;
            Debug.Log(bestY.ToString("f2"));
            Destroy(this.GetComponent<Detection>());
        }
    }
}
