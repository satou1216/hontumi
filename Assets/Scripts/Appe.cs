using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appe : MonoBehaviour
{
    [SerializeField]
    GameObject book, shadow;

    GameObject sha;
    bool set;
    float x, y;
    Vector3 mousevec;

   
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
        sha.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousevec.x + x, Screen.height / 4 + Screen.height / 2, 10f)); ;

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(sha);
            //mousevec.z = 10.0f;
            Instantiate(book, Camera.main.ScreenToWorldPoint(new Vector3(mousevec.x + x, Screen.height / 4 + Screen.height / 2, 10f)), Quaternion.identity);

            set = false;
            sha = Instantiate(shadow, Camera.main.ScreenToWorldPoint(new Vector3(mousevec.x + x, Screen.height / 4 + Screen.height / 2, 10f)), Quaternion.identity);
        }
    }

    public void a()
    {
        x += Random.Range(-30f, 30f);
        //y += Random.Range(-20f, 20f);
    }

}

