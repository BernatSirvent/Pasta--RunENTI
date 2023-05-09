using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class CharacterSelectionController : MonoBehaviour
{
    public Image[] playerSelectionImage = new Image[4];
    public int[] playerSelectionValue = new int[4];
    public bool[] playerSelectionAccepted = new bool[4];
    public int maxSelection = 4;
    public GameObject readyText = null;

    public Sprite duck;
    public Sprite octopus;
    public Sprite bear;
    public Sprite rabbit;
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            playerSelectionValue[i] = 0;
            playerSelectionAccepted[i] = false;
        }
        if (readyText != null)
        {
            readyText.SetActive(false);
        }
    }

    public void ChangeSelectionInputLeft(InputAction.CallbackContext Context)
    {
        if (!playerSelectionAccepted[0])
        {
            if (Context.performed)
            {
                ChangeSelection(0, false);
            }
        }
    }
    public void ChangeSelectionInputRight(InputAction.CallbackContext Context)
    {
        if (!playerSelectionAccepted[0])
        {
            if (Context.performed)
            {
                ChangeSelection(0, true);
            }
        }
    }
    public void ChangeSelectionAcceptInput(InputAction.CallbackContext Context)
    {
        if (!playerSelectionAccepted[0])
        {
            if (Context.performed)
            {
                AcceptSelection(0);
            }
        }
    }
    public void ChangeSelectionCancelInput(InputAction.CallbackContext Context)
    {
        if (!playerSelectionAccepted[0])
        {
            if (Context.performed)
            {
                CancelSelection(0);
            }
        }
    }
    void Update()
    {
        if (!playerSelectionAccepted[0])
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeSelection(0, false);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                ChangeSelection(0, true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                AcceptSelection(0);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CancelSelection(0);
            }
        }


        int numAccepted = 0;
        for (int i = 0; i < 4; i++)
        {

            if (playerSelectionAccepted[i])
            {
                numAccepted++;

            }
        }
        if (numAccepted >= 4)
        {
            readyText.SetActive(true);
        }
        else
        {
            readyText.SetActive(false);
        }
    }

    void ChangeSelection(int id, bool up)
    {
        if (id < 0 || id >= 4) { return; }

        if (up)
        {
            playerSelectionValue[id]++;
            if (playerSelectionValue[id] >= maxSelection)
            {
                playerSelectionValue[id] = 0;
            }
        }
        else
        {
            playerSelectionValue[id]--;
            if (playerSelectionValue[id] <= 0)
            {
                playerSelectionValue[id] = maxSelection - 1;
            }
        }
        switch (playerSelectionValue[id])
        {
            case 0:
                playerSelectionImage[id].sprite = duck;
                break;
            case 1:
                playerSelectionImage[id].sprite = octopus;
                break;
            case 2:
                playerSelectionImage[id].sprite = bear;
                break;
            case 3:
                playerSelectionImage[id].sprite = rabbit;
                break;

            default: break;
        }
    }

    void AcceptSelection(int id)
    {
        if (id < 0 || id >= 4) { return; }
        playerSelectionAccepted[id] = true;
    }

    void CancelSelection(int id)
    {
        if (id < 0 || id >= 4) { return; }
        playerSelectionAccepted[id] = false;
    }
}
