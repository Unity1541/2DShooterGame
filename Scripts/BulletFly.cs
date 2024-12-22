using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public RectTransform bulletTransform;
    public float bulletSpeed = 18f;

    void Update()
    {
        Move();

    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.tag=="Enemy")
    //     {
    //          Debug.Log("Bullet has entered the trigger!");
    //          gameObject.SetActive(false);

    //     }
    // }

    public void Move()
    {
        Vector2 moveDirection = new Vector2(0,1);
        bulletTransform.anchoredPosition += moveDirection*bulletSpeed;
    }

   
}
