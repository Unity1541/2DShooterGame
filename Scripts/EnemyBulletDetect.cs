using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyBulletDetect : MonoBehaviour
{
    public PlayerStatus playerStatus;
    public GameObject explosion;

    [SerializeField] private float flashDuration = 0.2f; // 每次閃爍的持續時間
    [SerializeField] private int flashCount = 1;        // 閃爍次數

    private SpriteRenderer spriteRenderer;

    void Start ()
    {
        

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            playerStatus = GameObject.FindObjectOfType<PlayerStatus>();
            IDamage damage = collider.gameObject.GetComponent<IDamage>();
            damage.HandleDamage(10f);
            float HP = playerStatus.slider.value;
            
            spriteRenderer = collider.gameObject.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
                {
                    // 保存初始顏色
                    Color originalColor = spriteRenderer.color;

                    // 使用 DOTween 改變 alpha 實現閃爍效果
                    spriteRenderer.DOFade(0.7f, flashDuration) // 透明
                        .SetLoops(flashCount, LoopType.Yoyo) // Yoyo: 透明-不透明-透明 循環
                        .OnComplete(() =>
                        {
                            // 恢復原始顏色
                            spriteRenderer.color = originalColor;
                        });
                }
             
            
            this.gameObject.SetActive(false);
            
            if (HP<=0)
            {
                Instantiate(explosion,this.transform.position, Quaternion.identity);
                Destroy(collider.gameObject);
            }
              
        }
    }
     
}
