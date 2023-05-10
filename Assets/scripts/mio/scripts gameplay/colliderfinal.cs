using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderfinal : MonoBehaviour
{
    public winnerdetector winDetect;
    public Animator transition;
    public Collider2D p1col;
    public Collider2D p2col;
    public Collider2D p3col;
    public Collider2D p4col;

    public void Awake()
    {

        Physics2D.IgnoreCollision(p1col.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(p2col.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(p3col.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(p4col.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
    }
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
