using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupsalto : MonoBehaviour
{
    public float multiplier = 4.0f;
    public cameracontrol shakecam;
    [SerializeField] private AudioSource pickupsound;

    public void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickupsound.Play();
            Pickup(other);
            
        }
    }

    void Pickup(Collider2D player)
    {
        transform.position = new Vector2(-1000, -1000);
    }

}
