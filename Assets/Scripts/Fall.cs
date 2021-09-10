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
        
        if (collision.gameObject.tag == "book"|| collision.gameObject.tag == "Untagged")
        {
            //��
            g.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;

        }

    }

    public void title()
    {
        Detection.bestY = 0;
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void game()
    {
        Detection.bestY = 0;
        SceneManager.LoadScene("MainGame");
        Time.timeScale = 1;
    }

    public void end()
    {
        g.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void credit()
    {
        Detection.bestY = 0;
        SceneManager.LoadScene("Credit");
        Time.timeScale = 1;
    }

    public void endgame()
    {
        Detection.bestY = 0;
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
              UnityEngine.Application.Quit();
        #endif
        Time.timeScale = 1;
    }

}
