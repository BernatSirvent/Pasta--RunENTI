using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextRound",15f);
    }

    private void NextRound()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
