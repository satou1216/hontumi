using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadLine : MonoBehaviour
{
    public float y=0.1f;

    //Detection maxY;
    [SerializeField]
    GameObject g;

    [SerializeField]
    Text t;

    // Start is called before the first frame update
    void Start()
    {
       // maxY = g.GetComponent<Detection>();
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += new Vector3(0, y*Time.deltaTime, 0);
        t.text = Detection.bestY.ToString("f2");

        if (this.transform.position.y >= Detection.bestY)
        {
            Debug.Log("gameover");
        }

    }

   /* public void addconp(GameObject g)
    {
        Destroy(maxY.GetComponent<Detection>());
        maxY = g.GetComponent<Detection>();
    }
    */
}
