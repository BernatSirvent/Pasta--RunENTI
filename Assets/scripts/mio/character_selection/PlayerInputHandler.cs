using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerconfig;
    private MovePlayer mover;

    [SerializeField]
    private Movimiento controls;
    [SerializeField]
    private GameObject characterprefab;

    private void Awake()
    {
        mover = GetComponent<MovePlayer>();
        controls = new Movimiento();
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerconfig = pc;
        //characterprefab = pc.PlayerPrefab;
        playerconfig.Input.onActionTriggered += Input_onActionTrigerred;
    }

    private void Input_onActionTrigerred(CallbackContext obj)
    {
        if(obj.action.name == controls.Player.Movimiento.name)
        {
            OnMove(obj);
        }
        if (obj.action.name == controls.Player.Movimiento.name)
        {
            OnJump(obj);
        }
    }
    public void OnJump(CallbackContext context)
    {
        if(mover != null)
            mover.Jump(context);
    }

    public void OnMove(CallbackContext context)
    {
        if(mover != null)
            mover.Move(context);
    }
}
