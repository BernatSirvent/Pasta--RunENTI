using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public playerspositioncontroller playersposition;
    public CameraMove cameraposition;
    public Animator transition;
    public Vector2 winPosition1;
    public Vector2 winPosition2;
    public Vector2 winPosition3;
    public Vector2 winPosition4;
    public MovePlayer p1script;
    public MovePlayer p2script;
    public MovePlayer p3script;
    public MovePlayer p4script;
    public float winpositionchanger;
    public GameObject muertelastwinner;
    public muertedetector deathdetector;
    public winnerdetector Winnerdetector;
    Scene m_Scene;
    public string sceneName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        winpositionchanger = 0;
    }
    public void Update()
    {

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if (this != null)
        {
            if (sceneName == "Map4")
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }
    }
    public void NextRoundByDeath()
    {
        
        muertelastwinner.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GiveWin();
        playersposition.ChangedActiveScene();
        cameraposition.ChangedActiveSceneCam();
        deathdetector.gameObject.SetActive(true);
        deathdetector.contador_muertes = 0;
        Winnerdetector.IsitTIE();

    }

    public void NextRoundByCollision()
    {
        
        muertelastwinner.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playersposition.ChangedActiveScene();
        cameraposition.ChangedActiveSceneCam();
        deathdetector.gameObject.SetActive(true);
        deathdetector.contador_muertes = 0;

        p1script.died_thisRound = false;
        p2script.died_thisRound = false;
        p3script.died_thisRound = false;
        p4script.died_thisRound = false;
        Winnerdetector.IsitTIE();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        muertelastwinner.SetActive(false);
        if (collision.gameObject.name.Equals("Conejo"))
        {
            p4script.win++;
        }
        if (collision.gameObject.name.Equals("Puplo"))
        {
            p3script.win++;
        }
        if (collision.gameObject.name.Equals("Pato"))
        {
            p2script.win++;
        }
        if (collision.gameObject.name.Equals("Osa"))
        {
            p1script.win++;
        }
        changewinPosition();
        transition.Play("trans");
        Invoke("NextRoundByCollision", 0.76f);

    }

    public void triggerenter2d()
    {
        changewinPosition();
        transition.Play("trans");
        Invoke("NextRoundByDeath", 0.76f);
        this.gameObject.SetActive(true);
        Winnerdetector.tie = false;

    }

    public void GiveWin()
    {

        if (p1script.died_thisRound == false)
        {
            p1script.win++;
        }
        if (p2script.died_thisRound == false)
        {
            p2script.win++;
        }
        if (p3script.died_thisRound == false)
        {
            p3script.win++;
        }
        if (p4script.died_thisRound == false)
        {
            p4script.win++;
        }

        p1script.died_thisRound = false;
        p2script.died_thisRound = false;
        p3script.died_thisRound = false;
        p4script.died_thisRound = false;


    }

    public void changewinPosition()
    {
        if (winpositionchanger == 0)
        {

            transform.position = winPosition1;
            winpositionchanger = winpositionchanger + 1;
        }
        else if (winpositionchanger == 1)
        {

            transform.position = winPosition2;
            winpositionchanger = winpositionchanger + 1;
        }
        else if (winpositionchanger == 2)
        {
            transform.position = winPosition3;
            winpositionchanger = winpositionchanger + 1;
        }
        else if (winpositionchanger == 3)
        {
            transform.position = winPosition4;
            winpositionchanger = winpositionchanger + 1;
        }

    }

}