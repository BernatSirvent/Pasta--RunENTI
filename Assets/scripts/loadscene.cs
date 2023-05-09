using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscene : MonoBehaviour
{
    public GameObject objectToTrue;
    public GameObject objectToFalse;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void WhenButtonIsPressed()
    {
        if(objectToTrue.activeInHierarchy == false)
        {
            objectToTrue.SetActive(true);
            objectToFalse.SetActive(false);
            
        }
    }
}
