using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerSetupMenuController : MonoBehaviour
{

    private int PlayerIndex;

    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;

    private float ignoreInputTime = 1.5f;
    private bool inputEnabled;

    public void SetPlayerIndex(int pi)
    {
        PlayerIndex = pi;
        titleText.SetText("Player "+ (pi + 1).ToString());
        ignoreInputTime = Time.time + ignoreInputTime; 
    }

    void Update()
    {
        if(Time.time > ignoreInputTime)
        {
            inputEnabled = true;
        }
    }

    public void SetPrefab(GameObject prefab)
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.SetPlayerPrefab(PlayerIndex, prefab);
        readyPanel.SetActive(true);
        readyButton.Select();
        menuPanel.SetActive(true);
    }

    public void ReadyPlayer()
    {
        if (!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(PlayerIndex);
        readyButton.gameObject.SetActive(false);
    }
}
