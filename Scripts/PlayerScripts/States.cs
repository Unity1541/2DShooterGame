using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class States 
{
    public PlayerController playerController;
    public StateMachine stateMachine;
    public bool isMove,isShoot;
    public States(PlayerController _playerController,StateMachine _stateMachine)
    {
        playerController = _playerController;
        stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {

    }
    public virtual void Input()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void Exit()
    {

    }
    
}
