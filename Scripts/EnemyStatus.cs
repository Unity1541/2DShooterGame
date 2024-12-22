using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//這樣才有Slider元件

public class EnemyStatus : MonoBehaviour,IDamage
{
    // public SpriteRenderer _spriteRenderer;
    // [Tooltip("Damage所需要的時間")]
    // public float _flashDuration;
    // [Tooltip("Damage的閃爍次數")]
    // [Range(0f, 4f)]
    // public int _flashNumber;
    // public Color _flashColor;

    [Tooltip("血量")]
    public float HP=100f;
    public Slider slider;
    public bool isDead;
    

    public void HandleDamage(float damage)
    {
        slider.value-=damage;
        HP = slider.value;
    } 
}
