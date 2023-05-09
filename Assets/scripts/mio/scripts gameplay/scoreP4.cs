using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreP4 : MonoBehaviour
{
    public MovePlayer p4;
    public int startWin;
    public TMP_Text wins;

    void Update()
    {
        wins.SetText(""+ p4.win);
    }
}
