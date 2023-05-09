using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botonplay : MonoBehaviour
{

    public void SceneLoad()
    {
        StartCoroutine(waitThenLoad());
    }
    private IEnumerator waitThenLoad()
    {
        yield return new WaitForSecondsRealtime(2.247f);
        SceneManager.LoadScene("MapaInicio");
    }
}
