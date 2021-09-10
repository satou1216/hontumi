using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
  static public  float bestY = 0;
    float height;

    //[SerializeField]
    //GameObject dodai;

    List<GameObject> bookList = new List<GameObject>();

    DeadLine dead;

    SoundManager SM;

    // Start is called before the first frame update
    void Start()
    {
        height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        dead = GameObject.Find("Deadline").GetComponent<DeadLine>();
        SM = GameObject.Find("MainCamer").GetComponent<SoundManager>();
        //bookList.Add(dodai);
        //dead = GameObject.Find("Deadline").GetComponent<DeadLine>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* if (collision.gameObject.tag == "top")
         {
             this.tag = "book";
             Destroy(this.GetComponent <Detection> ());
         }
         */
        if (collision.gameObject.tag != "Untagged")
        {
            SM.sePlay("putting_a_book2");
            //dead.addconp(bookList[bookList.Count-1]);
            bookList.Add(collision.gameObject);
            bestY = bookList[bookList.Count-1].gameObject.transform.position.y + height;

            if (bookList[bookList.Count - 1].gameObject.transform.position.y>= bookList[bookList.Count - 1].gameObject.transform.position.y-0.1) {
                bookList[bookList.Count - 1].gameObject.tag = "Untagged";
            }
            dead.Y = bestY;
            // Debug.Log(bestY.ToString("f2"));

            if (bookList.Count != 1)
            {
                Destroy(bookList[bookList.Count - 2].GetComponent<Detection>());
            }
            else
            {
                Destroy(bookList[bookList.Count - 1].GetComponent<Detection>());
            }
        }
    }
}
