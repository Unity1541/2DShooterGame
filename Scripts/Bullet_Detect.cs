using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Detect : MonoBehaviour
{

    public Bullet_Detect_Model bulletModel;
    private SpriteRenderer spriteRenderer;
    private EnemyStatus enemyStatus;
    private Shoot_Bullet shoot_Bullet;

    
    

    void Awake()
    {
        enemyStatus =  GameObject.FindObjectOfType<EnemyStatus>();
        shoot_Bullet = GameObject.FindObjectOfType<Shoot_Bullet>();
        
        GameObject enemy_Object = GameObject.Find("EnemyTransform");
        
        if (enemy_Object==null)
        {
            return;
            //如果有發生return,那麼之後的程式碼都不會執行，包含else之後也不會，因此要把程式碼往前提
        }
        else
        {
            bulletModel.sprite_Flash =enemy_Object.GetComponentInChildren<Sprite_Flash>();
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Boss")
        {
            
             bulletModel.obtain_gameObject = collision.gameObject;
             bulletModel.explodePosition=collision.gameObject.GetComponent<RectTransform>();
             spriteRenderer = bulletModel.obtain_gameObject.GetComponentInChildren<SpriteRenderer>();
             gameObject.SetActive(false);
             ISPrite_Flash iSPrite_Flash = collision.gameObject.GetComponentInChildren<ISPrite_Flash>();
             
             if (iSPrite_Flash!=null)
                iSPrite_Flash.FlashSprite(spriteRenderer,3,Color.black,3);
             
             
             RectTransform rectTransform = collision.GetComponent<RectTransform>();
             GameObject obj = Instantiate(bulletModel.hitVFX,rectTransform);
             //只要有Insntatntiate有放入(,第二個參數)，這樣生成出來的東西，會自動變成他的child
             //即使有SetParent(,false)，也只是位子不隨Parent移動，但是仍然是Child
             // Local Position and Rotation: 
             // The false in SetParent(rectTransform, false) means that the local position and rotation of obj will not be adjusted relative to rectTransform. 
             // Instead, it will keep its original local transform settings.
             // obj.transform.position = someWorldPosition; 這樣可以避開，變成Child，而位子自己在設定就好了
             // Becoming a Child: If you don't want the instantiated object to be a child of rectTransform, 
             //you should not set the parent during instantiation. 
             //Instead, you can simply instantiate it without a parent and then set the parent afterward only if you need to.
             obj.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
             IDamage damage = collision.gameObject.GetComponentInChildren<IDamage>();
             damage.HandleDamage(shoot_Bullet.weapon.weapon_damage);
             EnemyStatus enemyStatus = collision.gameObject.GetComponentInChildren<EnemyStatus>(); 
             if(enemyStatus.HP<=0)
             {   
                 enemyStatus.isDead = true;
                 spriteRenderer.enabled = false; // Hides the sprite
                 GameObject obj_explode = Instantiate(bulletModel.explodeGameObject,bulletModel.explodePosition);
                 obj_explode.GetComponent<RectTransform>().anchoredPosition = bulletModel.explodePosition.anchoredPosition;
                 bulletModel.obtain_gameObject.GetComponent<Collider2D>().enabled = false;
                 //死亡爆炸畫面只出現一次後，關掉Collider2D
                 GameObject HPBar = GameObject.Find("HPBar");
                 HPBar.SetActive(false);       
             }
               
        }

        if(collision.tag=="Enemy")
        {
                 bulletModel.obtain_gameObject = collision.gameObject;
                 bulletModel.explodePosition=collision.gameObject.GetComponent<RectTransform>();
                 spriteRenderer = bulletModel.obtain_gameObject.GetComponentInChildren<SpriteRenderer>();
                 spriteRenderer.enabled = false; // Hides the sprite
                 GameObject obj_explode = Instantiate(bulletModel.explodeGameObject,bulletModel.explodePosition);
                 obj_explode.GetComponent<RectTransform>().anchoredPosition = bulletModel.explodePosition.anchoredPosition;
                 bulletModel.obtain_gameObject.GetComponent<Collider2D>().enabled = false;
                 gameObject.SetActive(false);
        }

    }
}
