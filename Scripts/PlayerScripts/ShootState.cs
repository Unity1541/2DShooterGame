using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : States
{
   public ShootState(PlayerController _playerController,StateMachine _stateMachine) : base(_playerController,_stateMachine)
    {
        playerController = _playerController;
        stateMachine =_stateMachine;
    }
}
