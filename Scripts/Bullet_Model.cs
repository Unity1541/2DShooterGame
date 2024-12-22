using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "attackMenu/Weapon")]
public class Bullet_Model : ScriptableObject
{
    public GameObject hitVFX;
    public ParticleSystem muzzleFlash;
    public GameObject gameObjectbullet;
    public int attack_power,amountBullet;
    public GameObject explodeObject;
    
}
