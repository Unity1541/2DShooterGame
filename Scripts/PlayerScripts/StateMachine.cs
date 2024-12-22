using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public States currentState;
    public void Initiate(States startState)
    {
        currentState = startState;
        startState.Enter();
    }

    public void ChangeState(States newState)
    {
        currentState.Exit();//由這邊執行個別state裡面的Exit方法，更新參數後

        currentState = newState;
        newState.Enter();//一旦進入新狀態之後，就會更新所需要的參數,其它logicUpdate(),PhysicsUpdate()在CharacterController更新
    }
}
