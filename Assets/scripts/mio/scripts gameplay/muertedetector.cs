using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muertedetector : MonoBehaviour
{
    public int contador_muertes;
    public GameObject muertelastwinner;

    private void Update()
    {
        if(contador_muertes >= 2)
        {
            muertelastwinner.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            contador_muertes = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("He sumado 1 al contador de muertes");
        contador_muertes++;
    }
}
