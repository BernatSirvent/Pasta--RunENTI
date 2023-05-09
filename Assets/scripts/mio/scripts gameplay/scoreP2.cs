using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreP2 : MonoBehaviour
{
    public MovePlayer p2;
    public int startWin;
    public TMP_Text wins;

    void Update()
    {
        wins.SetText(""+ p2.win);
    }
}
