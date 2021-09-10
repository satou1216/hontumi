using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fall : MonoBehaviour
{
    [SerializeField]
    GameObject g;

    [SerializeField]
    Text t,ima;

    DeadLine d;

    private SoundManager SM;

    // Start is called before the first frame update
    void Start()
    {
        d = GameObject.Find("Deadline").GetComponent<DeadLine>();
        SM = GameObject.Find("MainCamer").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "book"|| collision.gameObject.tag == "Untagged")
        {
            //‰¹
            /* g.SetActive(true);
             Cursor.visible = true;
             Time.timeScale = 0;
             */
            end();
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
        Time.timeScale = 1;
        Detection.bestY = 0;
        SceneManager.LoadScene("MainGame");
        
    }

    public void end()
    {
       // PlayerPrefs.GetFloat("SCORE",0);
        g.SetActive(true);

        ima.text=d.Y.ToString("f2");
        SM.sePlay("resultSE");

        if (PlayerPrefs.GetFloat("SCORE", 0) < d.Y)
        {
            PlayerPrefs.SetFloat("SCORE", d.Y);
            PlayerPrefs.Save();
        }
        t.text= PlayerPrefs.GetFloat("SCORE", 0).ToString("f2");
        
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void credit()
    {
        Time.timeScale = 1;
        Detection.bestY = 0;
        SceneManager.LoadScene("Credit");
        Time.timeScale = 1;
    }

    public void endgame()
    {
        Time.timeScale = 1;
        Detection.bestY = 0;
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
              UnityEngine.Application.Quit();
        #endif
        
    }

}
