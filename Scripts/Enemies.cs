using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public RectTransform rectTransform;
    public float timeForShoot;
    public GameObject enemyBullet;
    

    void Start()
    {
        
        RectTransform bulletTransform = enemyBullet.GetComponent<RectTransform>();
        Instantiate(enemyBullet, rectTransform.parent);
        bulletTransform.anchoredPosition = new Vector2(0,1.2f);
    }

    void LateUpdate()
    {
        
    }

  

}
