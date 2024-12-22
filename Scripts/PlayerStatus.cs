using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//對應UI的slider
using TMPro;


public class PlayerStatus : MonoBehaviour,IDamage
{
    [Tooltip("血量")]
    public float HP=100f;
    public Slider slider;
    public bool isDead;
    public TextMeshProUGUI textMeshProUGUI;
    

    public void HandleDamage(float damage)
    {
        slider.value-=damage;
        HP = slider.value;
        textMeshProUGUI.text = HP.ToString();
    } 
}
