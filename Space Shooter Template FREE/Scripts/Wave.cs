using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This script generates an enemy wave. It defines how many enemies will be emerging, their speed and emerging interval. 
/// It also defines their shooting mode. It defines their moving path.
/// </summary>
[System.Serializable]
public class Shooting
{//一個繼承 MonoBehaviour的class可以包含其他的class作為其成員。
//Wave 繼承了 MonoBehaviour，
//並且包含了一個Shooting類型的成員變數shooting。
//這種方式被稱為「組合」(composition)
    [Range(0,100)]
    [Tooltip("probability with which the ship of this wave will make a shot")]
    public int shotChance;

    [Tooltip("min and max time from the beginning of the path when the enemy can make a shot")]
    public float shotTimeMin, shotTimeMax;
}

public class Wave : MonoBehaviour {                 
    #region FIELDS
    [Tooltip("Enemy's prefab")]
    public GameObject enemy;

    [Tooltip("a number of enemies in the wave")]
    public int count;

    [Tooltip("path passage speed")]
    public float speed;

    [Tooltip("time between emerging of the enemies in the wave")]
    public float timeBetween;

    [Tooltip("points of the path. delete or add elements to the list if you want to change the number of the points")]
    public Transform[] pathPoints;//預設三個點，敵人通過的路徑，設定為Enemy的子物件

    [Tooltip("whether 'Enemy' rotates in path passage direction")]
    public bool rotationByPath;

    [Tooltip("if loop is activated, after completing the path 'Enemy' will return to the starting point")]
    public bool Loop;

    [Tooltip("color of the path in the Editor")]
    public Color pathColor = Color.yellow;
    public Shooting shooting;//剛剛被建立的序列化class，要宣告才能使用

    [Tooltip("if testMode is marked the wave will be re-generated after 3 sec")]
    public bool testMode;
    #endregion

    private void Start()
    {
        StartCoroutine(CreateEnemyWave()); 
    }

    IEnumerator CreateEnemyWave() //depending on chosed parameters generating enemies and defining their parameters
    {
        for (int i = 0; i < count; i++) 
        {
            // enemy.transform.position就是原來場景上的位置
            GameObject newEnemy;
            newEnemy = Instantiate(enemy, enemy.transform.position, Quaternion.identity);
            FollowThePath followComponent = newEnemy.GetComponent<FollowThePath>(); 
            followComponent.path = pathPoints;         
            followComponent.speed = speed;        
            followComponent.rotationByPath = rotationByPath;
            followComponent.loop = Loop;
            followComponent.SetPath(); 
            Enemy enemyComponent = newEnemy.GetComponent<Enemy>();  
            enemyComponent.shotChance = shooting.shotChance; 
            enemyComponent.shotTimeMin = shooting.shotTimeMin; 
            enemyComponent.shotTimeMax = shooting.shotTimeMax;
            newEnemy.SetActive(true);      
            yield return new WaitForSeconds(timeBetween);
            //這邊是說，每生成一個敵人到下一個敵人之間的間隔時間
            //以免每一位都是重疊在一起。這樣可以避免敵人同時生成，達到「逐個生成敵人」的效果。 
        }
        if (testMode)       //if testMode is activated, waiting for 3 sec and re-generating the wave
        {
            yield return new WaitForSeconds(3);
            // 這個等待只會在 testMode 為 true 的情況下執行，用於在生成整個波次後等待 3 秒。
            // 等待 3 秒之後，重新啟動 CreateEnemyWave() 協程，生成新的一波敵人。
            StartCoroutine(CreateEnemyWave());
        }
        else if (!Loop)
            Destroy(gameObject); 
    }

    void OnDrawGizmos()  
    {
        DrawPath(pathPoints);  
    }

    void DrawPath(Transform[] path) //drawing the path in the Editor
    {
        Vector3[] pathPositions = new Vector3[path.Length];
        for (int i = 0; i < path.Length; i++)
        {
            pathPositions[i] = path[i].position;
        }
        Vector3[] newPathPositions = CreatePoints(pathPositions);
        Vector3 previosPositions = Interpolate(newPathPositions, 0);
        Gizmos.color = pathColor;
        int SmoothAmount = path.Length * 20;
        for (int i = 1; i <= SmoothAmount; i++)
        {
            float t = (float)i / SmoothAmount;
            Vector3 currentPositions = Interpolate(newPathPositions, t);
            Gizmos.DrawLine(currentPositions, previosPositions);
            previosPositions = currentPositions;
        }
    }

    Vector3 Interpolate(Vector3[] path, float t) 
    {
        int numSections = path.Length - 3;
        int currPt = Mathf.Min(Mathf.FloorToInt(t * numSections), numSections - 1);
        float u = t * numSections - currPt;
        Vector3 a = path[currPt];
        Vector3 b = path[currPt + 1];
        Vector3 c = path[currPt + 2];
        Vector3 d = path[currPt + 3];
        return 0.5f * ((-a + 3f * b - 3f * c + d) * (u * u * u) + (2f * a - 5f * b + 4f * c - d) * (u * u) + (-a + c) * u + 2f * b);
    }

    Vector3[] CreatePoints(Vector3[] path)  //using interpolation method calculating the path along the path points
    {
        Vector3[] pathPositions;
        Vector3[] newPathPos;
        int dist = 2;
        pathPositions = path;
        newPathPos = new Vector3[pathPositions.Length + dist];
        Array.Copy(pathPositions, 0, newPathPos, 1, pathPositions.Length);
        newPathPos[0] = newPathPos[1] + (newPathPos[1] - newPathPos[2]);
        //最後一個控制點（newPathPos[newPathPos.Length - 1]）：
        //使用倒數第二和第三個控制點的差來計算，以延伸到路徑的結束方向。
        newPathPos[newPathPos.Length - 1] = newPathPos[newPathPos.Length - 2] + (newPathPos[newPathPos.Length - 2] - newPathPos[newPathPos.Length - 3]);
        if (newPathPos[1] == newPathPos[newPathPos.Length - 2])
        {//檢查第二個和倒數第二個控制點是否相同，這意味著路徑上存在重複點。
        // 如果發現重複點，則創建一個新的LoopSpline陣列，將newPathPos複製過去。
        // 將LoopSpline的第一個點設置為第三個倒數的點，以便創建一個平滑的循環。
        // 將最後一個點設置為LoopSpline的第二個點。最後，將newPathPos更新為新的LoopSpline。
            Vector3[] LoopSpline = new Vector3[newPathPos.Length];
            Array.Copy(newPathPos, LoopSpline, newPathPos.Length);
            LoopSpline[0] = LoopSpline[LoopSpline.Length - 3];
            LoopSpline[LoopSpline.Length - 1] = LoopSpline[2];
            newPathPos = new Vector3[LoopSpline.Length];
            Array.Copy(LoopSpline, newPathPos, LoopSpline.Length);
        }
        return (newPathPos);
    }
}
