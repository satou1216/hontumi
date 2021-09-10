using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollbarCrickCheck : MonoBehaviour
{
    Vector3 position;
    Vector3 screenToWorldPointPosition;

    bool clicktoscrollbar = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void useScrollbar()
    {
        position = Input.mousePosition;
        position.z = 10f;
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        if (Input.GetMouseButtonDown(0))
        {

            var length = Vector3.Distance(new Vector3(transform.position.x,0,0), new Vector3(position.x,0,0));
            if (length < 10f)
            {
                //Debug.Log("1");
                clicktoscrollbar = true;


            }
            else
            {
                clicktoscrollbar = false;
            }


        }
        if (Input.GetMouseButtonUp(0))
        {
            clicktoscrollbar = false;
        }
    }
}
