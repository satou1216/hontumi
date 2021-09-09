using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLine : MonoBehaviour
{
    public float y=0.1f;

    //Detection maxY;
    //[SerializeField]
    //GameObject g;

    [SerializeField]
    Text t;
    [SerializeField]
    GameObject fall;

    public float Y=0;

    // Start is called before the first frame update
    void Start()
    {
        // maxY = g.GetComponent<Detection>();
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += new Vector3(0, y*Time.deltaTime, 0);
        t.text = Y.ToString("f2");

        if (this.transform.position.y >= Y)
        {
            //Debug.Log("gameover");
            fall.GetComponent<Fall>().end();
        }

    }

   /* public void addconp(GameObject g)
    {
        Destroy(maxY.GetComponent<Detection>());
        maxY = g.GetComponent<Detection>();
    }
    */
}
