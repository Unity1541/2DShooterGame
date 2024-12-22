using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public RectTransform shootTransform;
    public Vector2 moveDirection;
    public float moveSpeed;
    public FixedJoystick fixedJoystick;
    public Vector2 anchorPosition;
    public Vector2 newPosition;
    public RectTransform rectTransform;
    public float min_X,min_Y,max_X,max_Y;
    public MoveState moveState;
    public ShootState shootState;
    public StateMachine stateMachine;
    
    void Start()
    {
        Application.targetFrameRate = 200;
        stateMachine = new StateMachine();
        moveState = new MoveState(this,stateMachine);
        shootState = new ShootState(this,stateMachine);
        stateMachine.Initiate(moveState);

       
    }

    
    //void FixedUpdate()
    // {//由於這邊particleSystem是在3D相機下運行，因此Canvas渲染要改成Screen Space Camera
    //  //在使用 Screen Space - Camera模式時，RectTransform的位置（anchoredPosition）
    //  //與Rigidbody2D的位置可能會發生衝突，導致移動的Sprite在畫面上消失。
    //  //這是因為Screen Space - Camera的UI元素與世界空間中的對象使用的是不同的坐標系統。
    //  //解決方法之一，放棄rigidbody的移動方式，而是改成控制RectTransform的位置。
    // //因此也不要用FixedUpdate()
    //     // moveDirection = new Vector2(fixedJoystick.Direction.x, fixedJoystick.Direction.y).normalized;
    //     // moveDirection.x = Mathf.Clamp(moveDirection.x,min_X, max_X);
    //     // rigidbody.velocity = moveDirection*moveSpeed;
    //     // rectTransform.anchoredPosition = moveDirection;
    //     // anchorPosition = rectTransform.anchoredPosition;
    //     // anchorPosition.x = Mathf.Clamp(anchorPosition.x, min_X, max_X);
    //     // rectTransform.anchoredPosition = anchorPosition;
    //     // 獲取搖桿的輸入方向，並按速度計算移動量
    // }

    void Update()
    {
        moveDirection = new Vector2(fixedJoystick.Direction.x, fixedJoystick.Direction.y) * moveSpeed * Time.deltaTime;
        stateMachine.currentState.LogicUpdate();
        // 取得目前的錨點位置
        // newPosition = rectTransform.anchoredPosition;
        // // 計算新的位置
        // newPosition += moveDirection;
        // // 限制 X 和 Y 軸的移動範圍
        // newPosition.x = Mathf.Clamp(newPosition.x, min_X, max_X);
        // newPosition.y = Mathf.Clamp(newPosition.y, min_Y, max_Y);
        // // 更新 RectTransform 的位置
        // rectTransform.anchoredPosition = newPosition;
        
    }

   
}