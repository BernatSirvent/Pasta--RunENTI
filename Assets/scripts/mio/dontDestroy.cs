using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
   [SerializeField] private GameObject Object;


    public static dontDestroy Instance;
    private void Awake()
    {
        DontDestroyOnLoad(Object);
    }
}
