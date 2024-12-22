using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[System.Serializable]
public class PathRoute
{
    public int waypointCount = 3;            // 隨機路徑中的點數量
    public float pathRadius = 0.1f;          // 隨機路徑點生成的半徑
    public float moveDuration = 1f;          // 完成路徑所需的時間
    public bool loopPath = true;             // 是否循環路徑
}

public class Path_Controller : MonoBehaviour
{
    public PathRoute route;                  // 設置路徑屬性
    private RectTransform rectTransform;     // RectTransform組件
   

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 0);
        MoveAlongRandomPath();
    }

    void MoveAlongRandomPath()
    {
        // 生成隨機的路徑點
        Vector3[] waypoints = new Vector3[route.waypointCount];
        
        for (int i = 1; i < route.waypointCount; i++)
        {
            // 隨機生成位於指定半徑內的點 (X, Y)，並固定 Z 軸為 0
            waypoints[i] =  new Vector2(
                Mathf.Clamp(Random.Range(-route.pathRadius, route.pathRadius), -Screen.width / 3, Screen.width / 3),
                Mathf.Clamp(Random.Range(-route.pathRadius, route.pathRadius), -Screen.height / 2, Screen.height / 2)
            );
            waypoints[0].y +=2f;
        }


        // 使用 DOPath 讓 rectTransform 沿著這些點移動
        Tween pathTween = rectTransform.DOPath(waypoints, route.moveDuration, PathType.Linear)
            .SetEase(Ease.Linear); // 使用線性插值來進行平滑移動

        // 檢查是否需要循環路徑
        if (route.loopPath)
        {
            pathTween.SetLoops(-1, LoopType.Yoyo); // 路徑來回循環
        }

        pathTween.OnComplete(() =>
        {
            if (!route.loopPath)
            {
                // 若不循環，當路徑完成後重新生成新路徑
                MoveAlongRandomPath();
            }
        });
    }
}



