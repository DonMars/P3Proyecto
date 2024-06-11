using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Weapon",fileName = "New Weapon")]
public class WeaponStatsSO : ScriptableObject
{
    public int damage;
    public float range;
    public int ammo;
    public int magazineSize;
    public int maxAmmoCapacity;
    public float fireRate;
}
