using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerspositioncontroller : MonoBehaviour
{
    public Vector3 playerpositions;

    public GameObject p1char;
    public GameObject p2char;
    public GameObject p3char;
    public GameObject p4char;
    public Vector2 p1;
    public Vector2 p2;
    public Vector2 p3;
    public Vector2 p4;

    void Start()
    {

    }
    public void ChangedActiveScene()
    {
        transform.position = playerpositions;
        p1char.transform.position = p1;
        p2char.transform.position = p2;
        p3char.transform.position = p3;
        p4char.transform.position = p4;


    }
}
