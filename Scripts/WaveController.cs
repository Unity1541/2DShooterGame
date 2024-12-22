using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [System.Serializable]
    public class EnemyWaves 
    {
        [Tooltip("time for wave generation from the moment the game started")]
        public float timeToStart;

        [Tooltip("Enemy wave's prefab")]
        public GameObject enemy;
    }
    public float waitForWave;
    public EnemyWaves[] enemyWaves;

   void Start()
   {
        
        for (int i = 0; i < enemyWaves.Length;i++)
        {
            StartCoroutine(CreateWaves(enemyWaves[i].timeToStart,enemyWaves[i].enemy));
        }
        
       
        
   }
   IEnumerator CreateWaves(float delay, GameObject Wave)
   {
        if (delay != 0)
            yield return new WaitForSeconds(delay);  
        Instantiate(Wave);
   }

}
