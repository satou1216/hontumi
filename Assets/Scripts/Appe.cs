using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appe : MonoBehaviour
{
    [SerializeField]
    GameObject book, shadow,came;

    GameObject sha;
    bool set;
    float x, y;
    Vector3 mousevec,vec;


    void Start()
    {
        mousevec = Input.mousePosition;
        sha = Instantiate(shadow, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (set == false)
        {
            x = 0f;
            a();
            set = true;
        }

        mousevec = Input.mousePosition;
      vec=  Camera.main.ScreenToWorldPoint(mousevec);

        sha.transform.position = new Vector3(vec.x+x,Detection.bestY+3 , 10f); ;

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(sha);
            //mousevec.z = 10.0f;
            Instantiate(book, new Vector3(vec.x+x, Detection.bestY + 3, 10f), Quaternion.identity);

            set = false;
            sha = Instantiate(shadow, new Vector3(vec.x+x, Detection.bestY + 3, 10f), Quaternion.identity);
        }
    }

    public void a()
    {
        x += Random.Range(-1f, 1f);
        //y += Random.Range(-20f, 20f);
    }

}

