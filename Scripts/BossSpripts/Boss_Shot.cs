using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shot : MonoBehaviour
{
    public float timeInterval_shoot;
    public float timeLimit_shoot=0.001f;
    public ParticleSystem[] shootVFX;
    EnemyStatus enemyStatus;
    
    void Start ()
    {
        enemyStatus = GetComponent<EnemyStatus>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        timeInterval_shoot += Time.deltaTime;
        if (timeInterval_shoot >= timeLimit_shoot && !enemyStatus.isDead)
        {
            GameObject bullet = Boss_Bullet_Pool.instance.GetBullerPrefab();
            if (bullet != null)
            {
                bullet.SetActive(true);
                timeInterval_shoot = 0.0f; // Reset timer after shooting
            }
            else
            {
                Debug.LogWarning("Bullet prefab is null or Boss_Pool.instance is not initialized.");
            }
        }
    }
}
