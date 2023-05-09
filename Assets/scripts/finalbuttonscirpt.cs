using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalbuttonscirpt : MonoBehaviour
{
    Scene m_Scene;
    public string sceneName;

    public GameObject players;
    public GameObject winnerdetect1;
    public GameObject winnerdetect2;
    public GameObject canvasfinal;
    public GameObject PauseMenu;

    public GameObject lastbuttonexit;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if (lastbuttonexit != null)
        {
            if (sceneName == "FINALWINNER")
            {
                lastbuttonexit.gameObject.SetActive(true);
            }
            else
            {
                lastbuttonexit.gameObject.SetActive(false);
            }
        }
    }

    public void LoadMenu()
    {
        Destroy(players);
        Destroy(players);
        Destroy(winnerdetect1);
        Destroy(winnerdetect2);
        Destroy(canvasfinal);
        Destroy(PauseMenu);
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");

    }
}
