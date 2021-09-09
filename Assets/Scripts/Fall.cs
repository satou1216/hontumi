using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    [SerializeField]
    GameObject g;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "book")
        {
            //‰¹
            g.SetActive(true);
            Time.timeScale = 0;

        }

    }

    public void title()
    {
        Detection.bestY = 0;
        SceneManager.LoadScene("Title");
    }

    public void game()
    {
        Detection.bestY = 0;
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }

}
