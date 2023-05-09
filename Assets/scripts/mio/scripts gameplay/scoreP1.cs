using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreP1 : MonoBehaviour
{
    public MovePlayer p1;
    public int startWin;
    public TMP_Text wins;

    void Update()
    {
        wins.SetText(""+ p1.win);
    }
}
