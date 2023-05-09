using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastmuertewinner : MonoBehaviour
{
    public win Win;
    public GameObject win;
    public GameObject muerte;
    public GameObject thisgameobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        win.SetActive(false);
        thisgameobject.gameObject.SetActive(false);
        Win.triggerenter2d();
        Debug.Log("He Sumado 1 dentro de lastmuerte");
        
    }
}
