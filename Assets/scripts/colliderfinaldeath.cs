using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderfinaldeath : MonoBehaviour
{
    public GameObject objectToTrue;
    public GameObject objectToFalse;

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (objectToTrue.activeInHierarchy == false)
        {
            objectToTrue.SetActive(true);
            objectToFalse.SetActive(false);

        }
    }
}
