using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Bullet/Weapon")]
public class Bullet_Detect_Model : ScriptableObject
{
    public GameObject obtain_gameObject;//只是判斷撞到甚麼東西
    public GameObject explodeGameObject;
    public RectTransform explodePosition;
    public GameObject hitVFX;
    public Sprite_Flash sprite_Flash;
    public RectTransform rectTransform;
}

[System.Serializable]//可以在別的類別中(MonoBehaviour)，當作是序列化的參數出現在Inspector身上
public class Weapon 
{
  public float weapon_damage;
  public float weapon_power; 
}

