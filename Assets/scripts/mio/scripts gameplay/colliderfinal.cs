using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderfinal : MonoBehaviour
{
    public winnerdetector winDetect;
    public Animator transition;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        winDetect.IsitTIE();
        transition.Play("trans");
        Invoke("changescene", 0.76f);
    }

    public void changescene()
    {
        winDetect.IsitTIE();

        if (winDetect.tie == true)
        {
            winDetect.Tie();
        }
        else
        {
            winDetect.changeToFinal();
        }
    }
}
