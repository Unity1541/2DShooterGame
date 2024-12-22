using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<GameObject> poolObject = new List<GameObject>();
    public int amountBullet;
    public GameObject gameObject;
    public RectTransform spawn_rectTransform;

    public static ObjectPool instance;
    //其他類別都可以可以直接用，因為static的緣故
    //確保其他類別的程式碼可以直接用ObjectPool.instance.方法或.參數

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // 確保在此處不會有其他對象引用此單例
        }
    }
    void Start()
    {
        for (int i = 0; i < amountBullet;i++)
        {
            GameObject obj = Instantiate(gameObject, spawn_rectTransform); // 設置父物件
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0); // 設定相對於父物件的位置
            obj.SetActive(false);
            //obj.transform.SetParent(shoot_rectTransform);不一定要設定這個，因為產生出來就直接是子物件了
            poolObject.Add(obj);
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
