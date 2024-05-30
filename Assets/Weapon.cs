using System;
using UnityEngine;

/// <summary>
/// Van a realizar el disparo Automatico
/// Este debe de funcionar con el clic izquierdo del mouse
/// Y deben de usar todas las variables
/// Tambien se debe de programar la recarga del arma (feedback visual como un cisculo en el hud, o que en donde aparezcan las balas se escriba Reloading)
/// 
/// El disparo debe de funcionar por raycast.
/// Solo puedes recargar si tienes menos de la magazineSize
/// Al recargar se le deben de sumar balas de la maxAmmoCapacity
/// Debe de disparar automaticamente usando el fireRate del arma
/// </summary>
public class Weapon : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private WeaponSO weaponStats;
    [SerializeField] private LayerMask layers;

    private void Start()
    {
        weaponStats.ammo = weaponStats.maxAmmoCappacity;
        Debug.Log(weaponStats.ammo);
    }

    private Ray cameraRay;

    private void Update()
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        AutomaticFire();
        Reload();
    }

    private RaycastHit hit;

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && weaponStats.ammo < weaponStats.maxAmmoCappacity)
        {
            weaponStats.ammo = weaponStats.maxAmmoCappacity;
        }
    }

    private void AutomaticFire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && weaponStats.ammo > 0)
        {
            if (Physics.Raycast(cameraRay, out hit, range, layers))
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
        Gizmos.DrawRay(cameraRay.origin, cameraRay.direction * range);
    }
#endif

}
