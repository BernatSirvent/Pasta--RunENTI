using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class transicionmenu : MonoBehaviour { 

    [SerializeField] private GameObject transcion;

    public static transicionmenu Instance;
    private void Awake()
    {
            DontDestroyOnLoad(this.gameObject);
    }

    public void destroytransmenudef()
    {
        Invoke("destroytransmenu", 3f);
    }

    public void destroytransmenu()
    {
        Destroy(transcion); ;
    }

}
