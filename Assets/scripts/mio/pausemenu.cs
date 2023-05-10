using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{

    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseOptions;

    public GameObject target;
    public GameObject transicion;
    public GameObject victoria;
    public GameObject players;
    public GameObject muertepack;
    public GameObject winnerdetectorrr1;
    public GameObject winnerdetectorrr2;
    public GameObject canvasfinal;
    public GameObject colliderfinal;
    public GameObject Menupausa;

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void ShowPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        pauseOptions.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void DestroyAll()
    {
        Destroy(transicion);
        Destroy(target);
        Destroy(players);
        Destroy(muertepack);
        Destroy(victoria);
        Destroy(winnerdetectorrr1);
        Destroy(winnerdetectorrr2);
        Destroy(canvasfinal);
        Destroy(Menupausa);
        Destroy(colliderfinal);
    }

        public void LoadMenu()
    {
        Destroy(transicion);
        Destroy(target);
        Destroy(players);
        Destroy(muertepack);
        Destroy(victoria);
        Destroy(winnerdetectorrr1);
        Destroy(winnerdetectorrr2);
        Destroy(canvasfinal);
        Destroy(Menupausa);
        Destroy(colliderfinal);

        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}
