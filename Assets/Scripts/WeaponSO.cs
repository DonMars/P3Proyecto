using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Weapon",fileName = "New Weapon")]
public class WeaponSO : ScriptableObject
{
    public int damage;
    public int ammo;
    public int magazineSize;
    public int maxAmmoCappacity;
    public float fireRate;
    public WeaponFireTypeEnum fireType;
}
