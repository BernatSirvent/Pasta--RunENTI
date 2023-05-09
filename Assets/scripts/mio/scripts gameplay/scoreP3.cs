using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreP3 : MonoBehaviour
{
    public MovePlayer p3;
    public int startWin;
    public TMP_Text wins;

    void Update()
    {
        wins.SetText(""+ p3.win);
    }
}
