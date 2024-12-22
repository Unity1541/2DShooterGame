using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Bullet : MonoBehaviour
{
   public RectTransform rectTransform;
   public float offset;
   public ParticleSystem[] shootVFX;
   public Weapon weapon;
   public void Shoot()
   { //子彈的位置被設置為 rectTransform 的 anchoredPosition，這樣可以使子彈每次從物件池獲取時都回到特定的位置
     //不設定歸位的話，子彈下次啟動就會跑到其他地方去
       GameObject bullet = ObjectPool.instance.GetBullerPrefab();
       if (bullet != null)
       {
        //rectTransform的數字無法直接用float數字來修改，因此只能先用Vector2來修改
            Vector2 currentPosition = rectTransform.anchoredPosition; // 讀取當前的 anchoredPosition
            currentPosition.y = offset; //減去offset
            rectTransform.anchoredPosition = currentPosition; // 將新的位置賦值回去
            bullet.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
            bullet.SetActive(true);
       }
   }

    public void shoot_Bullet_VFX()
    {
        Debug.Log("有案到粒子效果");
        shootVFX[0].Play();
    }
}
