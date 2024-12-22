using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyPath : MonoBehaviour
{
    public RectTransform[] pathPoints; // 路徑點，使用 RectTransform
    public float moveSpeed = 2f;       // 移動速度（控制插值速度）
    public Vector2 boundary;          // 邊界限制（Canvas 的範圍，例如 x 和 y 的最大值）

    private int currentPointIndex = 0; // 當前目標點的索引
    private float t = 0f;              // 線性插值參數
    void Update()
    {
        if (pathPoints.Length < 2) return; // 如果路徑點不足，停止更新

        // 獲取當前和下一個控制點
        Vector3 startPoint = pathPoints[currentPointIndex].anchoredPosition;
        Vector3 endPoint = pathPoints[currentPointIndex + 1].anchoredPosition;
        t += Time.deltaTime * moveSpeed / Vector3.Distance(startPoint, endPoint);
        GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPoint, endPoint, t);
        // 當到達當前路徑點時，切換到下一段
        if (t >= 1f)
        {
            t = 0f; // 重置插值參數
            currentPointIndex++;

            // 如果已到達最後一個點，銷毀物件
            if (currentPointIndex >= pathPoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
        }

    }

    private void OnDrawGizmos()
    {
        // 繪製路徑線方便調試
        if (pathPoints.Length < 2) return;

        Gizmos.color = Color.green;
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }
    }
}
