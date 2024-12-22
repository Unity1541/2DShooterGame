using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : States
{
    bool isMove,isShoot;
    public MoveState(PlayerController _playerController,StateMachine _stateMachine) : base(_playerController,_stateMachine)
    {
        playerController = _playerController;
        stateMachine =_stateMachine;
        
    }

    public override void Enter()
    {
        Debug.Log("進入Move狀態");
    }

    public override void LogicUpdate()
    {
        playerController.newPosition = playerController.rectTransform.anchoredPosition;
        // 計算新的位置
        playerController.newPosition += playerController.moveDirection;
        // 限制 X 和 Y 軸的移動範圍
        playerController.newPosition.x = Mathf.Clamp(playerController.newPosition.x, playerController.min_X, playerController.max_X);
        playerController.newPosition.y = Mathf.Clamp(playerController.newPosition.y, playerController.min_Y, playerController.max_Y);
        // 更新 RectTransform 的位置
        playerController.rectTransform.anchoredPosition = playerController.newPosition;
    }

}
