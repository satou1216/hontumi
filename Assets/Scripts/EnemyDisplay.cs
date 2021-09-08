using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    public GameObject stage;
    Vector2 screen;
    Vector2 posA;
    float dis;
    // Start is called before the first frame update
    void Start()
    {
        posA = stage.transform.position;
        screen = new Vector2(Screen.width / 2, Screen.height / 2);
        dis = Vector3.Distance(screen, posA);
    }

    // Update is called once per frame
    void Update()
    {

        if (dis == 100)
        {
            this.gameObject.SetActive(true);
        }
    }
}
