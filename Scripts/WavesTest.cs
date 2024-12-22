using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesTest : MonoBehaviour
{
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
    [Tooltip("Enemy's prefab")]
    public GameObject enemy;
    [Tooltip("a number of enemies in the wave")]
    public int count;
    [Tooltip("time between emerging of the enemies in the wave")]
    public float timeBetween;
    public RectTransform enemySpawnTransorm;

    private void Start()
    {
        StartCoroutine(CreateEnemyWave()); 
    }

    IEnumerator CreateEnemyWave()
    {
        for (int i = 0;i < count; i++)
        {
            GameObject newEnemy;
            newEnemy = Instantiate(enemy, enemySpawnTransorm.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetween);
        }

    }

}
