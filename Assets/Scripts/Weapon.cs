using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponStatsSO weaponStats;
    [SerializeField] protected LayerMask layers;

    public bool hasAmmo => weaponStats.ammo > 0;

    public abstract void Shoot();

    public abstract void Aim();

    public abstract void Reload();

    public virtual void SpecialAction()
    {
        Debug.Log("Soy un arma :)");
    }

    #region Old
    private void Start()
    {
        //weaponStats.ammo = weaponStats.maxAmmoCapacity;
        //Debug.Log(weaponStats.ammo);
    }

    private Ray cameraRay;

    private void Update()
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        AutomaticFire();
        Reload();
    }

    private RaycastHit hit;

    //private void Reload()
    //{
    //    if (Input.GetKeyDown(KeyCode.R) && weaponStats.ammo < weaponStats.maxAmmoCapacity)
    //    {
    //        weaponStats.ammo = weaponStats.maxAmmoCapacity;
    //    }
    //}

    private void AutomaticFire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && weaponStats.ammo > 0)
        {
            if (Physics.Raycast(cameraRay, out hit, 20f, layers))
            {
                try
                {
                    hit.collider.GetComponent<Health>().Damage(weaponStats.damage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                weaponStats.ammo--;
            }
            else
            {
                Debug.Log("No aplica");
            }
        }
    }

#if UNITY_EDITOR
    [ExecuteInEditMode]
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(cameraRay.origin, cameraRay.direction * 20f);
    }
#endif
    #endregion
}