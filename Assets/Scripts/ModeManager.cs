using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    static public bool MainMode=true;
    /*Image image_component0;
    Image image_component1;
    Texture2D texture0;
    Texture2D texture1;
    Texture2D texture2;
    Texture2D texture3;*/

    CursorManagerV2 CM;
    //BirdAnimator BA;
    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        
        CM = GameObject.Find("Cursor").GetComponent<CursorManagerV2>();
        //BA = GameObject.Find("bird").GetComponent<BirdAnimator>();
        //BA = GameObject.Find("bird1").GetComponent<BirdAnimator>();
    }

    private void Update()
    {
        
    }
    // Update is called once per frame
    public void ButtonClick()
    {
        MainMode = !MainMode;
        if (MainMode)
        {
            CM.AttackModeOff();
            //BA.AttackModeOff();
            button1.SetActive(true);
            button2.SetActive(false);
            
        }
        else
        {
            CM.AttackModeOn();
            //BA.AttackModeOn();
            button2.SetActive(true);
            button1.SetActive(false);

        }
        Debug.Log(MainMode);
    }
}
