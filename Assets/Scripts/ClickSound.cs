using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    SoundManager SM;

    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.Find("Main Camera").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SM.sePlay("button1");
        }
    }
}
