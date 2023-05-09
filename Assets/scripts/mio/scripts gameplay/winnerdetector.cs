using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winnerdetector : MonoBehaviour
{
    public win Win;
    public Vector2 winnerPosition;
    public Vector2 loser1Position;
    public Vector2 loser2Position;
    public Vector2 loser3Position;

    public MovePlayer p1;
    public MovePlayer p2;
    public MovePlayer p3;
    public MovePlayer p4;
    public pausemenu destroyall;
    public muertedetector deathdetector;
    public playerspositioncontroller playerpositions;

    public GameObject p1GO;
    public GameObject p2GO;
    public GameObject p3GO;
    public GameObject p4GO;

    public GameObject muertelastwinner;
    public GameObject winnerdetector2;
    public GameObject Pausemenu;
    public GameObject Colliderfinal;


    public Animator transicion;

    public CameraMove cameraposition;
    public GameObject camara;
    public GameObject transi;
    public GameObject victory;
    public GameObject muertesite;
    Scene m_Scene;
    public string sceneName;

    public bool tie;

    public void Start()
    {
        tie = false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Tie()
    {
        if (tie == true)
        {

            transicion.Play("trans");
            destroyall.DestroyAll();
            SceneManager.LoadScene("MapaInicio");

        } 

    }

    public void DetectFinalWinner()
    {
        if (p1.win > p2.win && p1.win > p3.win && p1.win > p4.win)
        {
            Debug.Log("Player1 Won the game");
            p1GO.transform.position = winnerPosition;
            p2GO.transform.position = loser1Position;
            p3GO.transform.position = loser2Position;
            p4GO.transform.position = loser3Position;
        }
        else if (p2.win > p1.win && p2.win > p3.win && p2.win > p4.win)
        {
            Debug.Log("Player2 Won the game");
            p2GO.transform.position = winnerPosition;
            p1GO.transform.position = loser1Position;
            p3GO.transform.position = loser2Position;
            p4GO.transform.position = loser3Position;
        }

        else if (p3.win > p1.win && p3.win > p2.win && p3.win > p4.win)
        {
            Debug.Log("Player3 Won the game");
            p3GO.transform.position = winnerPosition;
            p2GO.transform.position = loser1Position;
            p1GO.transform.position = loser2Position;
            p4GO.transform.position = loser3Position;
        }

        else if (p4.win > p1.win && p4.win > p2.win && p4.win > p3.win)
        {
            Debug.Log("Player4 Won the game");
            p4GO.transform.position = winnerPosition;
            p2GO.transform.position = loser1Position;
            p3GO.transform.position = loser2Position;
            p1GO.transform.position = loser3Position;
        }
    }

    public void IsitTIE()
    {
        if (p1.win >= 2 && p1.win == p2.win)
        {
            tie = true;
        }
        else if (p1.win >= 2 && p1.win == p3.win)
        {
            tie = true;
        }
        else if (p1.win >= 2 && p1.win == p4.win)
        {
            tie = true;
        }
        else if (p2.win >= 2 && p2.win == p3.win)
        {
            tie = true;
        }
        else if (p2.win >= 2 && p2.win == p4.win)
        {
            tie = true;
        }
        else if (p3.win >= 2 && p3.win == p4.win)
        {
            tie = true;
        }
        else
        {
            tie = false;
        }
    }

    public void Update()
    {

        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if (winnerdetector2 != null)
        {
            if (sceneName == "Map4")
            {
                winnerdetector2.gameObject.SetActive(true);
            }
            else
            {
                winnerdetector2.gameObject.SetActive(false);
            }
        }
    

    }

    public void deletedontdeleteonload()
    {
        Destroy(transi);
        Destroy(muertesite);
        Destroy(victory);
        Destroy(Pausemenu);
        Destroy(Colliderfinal);
        Destroy(camara);
    }
    public void changeToFinal()
    {
        transicion.Play("trans");
        DetectFinalWinner();
        SceneManager.LoadScene("FINALWINNER");
        deletedontdeleteonload();
        Debug.Log("IChangedTo final");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        IsitTIE(); 

        if (tie == true)
        {
            Tie();
        }
        else
        {
            if (tie != true)
            {
                changeToFinal();
            }

        }
    }
}
