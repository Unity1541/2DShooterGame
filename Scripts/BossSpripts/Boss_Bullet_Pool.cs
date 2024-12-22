using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet_Pool : MonoBehaviour
{
    public Bullet_Model bossBullet;//專門給Boss的參數序列化
    public List<GameObject> poolObject = new List<GameObject>();
    public RectTransform spawn_boss_bullet;
    public static Boss_Bullet_Pool instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent multiple instances
        }
    }
    void Start()
    {
        for (int i = 0; i < bossBullet.amountBullet; i++)
        {
            GameObject bulletObj = Instantiate(bossBullet.gameObjectbullet,spawn_boss_bullet);
            bulletObj.GetComponent<RectTransform>().anchoredPosition = spawn_boss_bullet.anchoredPosition; 
            // 設定相對於父物件的位置
            bulletObj.SetActive(false);
            //bulletObj.transform.SetParent(this.transform,true);//不一定要設定這個，因為產生出來就直接是子物件了
            poolObject.Add(bulletObj);
        }
        
    }

    public GameObject GetBullerPrefab()
    {
        for (int i = 0;i<poolObject.Count;i++)
        {
            if(!poolObject[i].activeInHierarchy)//假設沒有被啟用的話
            //activeInHierarchy是一個屬性，用來判斷物件在場景中是否被啟用。
            //在Unity中，activeInHierarchy 屬性會返回一個布林值 (true 或 false) 來告訴我們物件在場景中的啟用狀態：
            //當activeInHierarchy是true，表示該物件在場景中被啟用，可以被看到或互動。
            //當activeInHierarchy是false，表示該物件在場景中沒有被啟用（可能是被禁用，或是父物件被禁用）。
            {
                return poolObject[i];
                //!poolObject[i].activeInHierarchy 意思是「如果這個物件沒有被啟用」，則它可以被重新使用。
            }
        }
        return null;
    }
}
