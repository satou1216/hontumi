using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titleanims : MonoBehaviour
{
    GameObject title1;
    GameObject title2;
    GameObject title3;
    GameObject title4;
    GameObject title5;
    
    // Start is called before the first frame update
    void Start()
    {
        
        title1 = GameObject.Find("Title2");
        title2 = GameObject.Find("book2");
        title3 = GameObject.Find("book3");
        title4 = GameObject.Find("Title1");
        title5 = GameObject.Find("book1");

        Invoke("Anim1", 1);
        Invoke("Anim2", 1.5f);
        Invoke("Anim3", 2.5f);
        Invoke("Anim4", 3.5f);
        Invoke("Anim5", 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Anim1()
    {
        title1.SetActive(true);
    }

    void Anim2()
    {
        title2.SetActive(true);
    }

    void Anim3()
    {
        title3.SetActive(true);
    }

    void Anim4()
    {
        title4.SetActive(true);
    }

    void Anim5()
    {
        title5.SetActive(true);
    }
}
