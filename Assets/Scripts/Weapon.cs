using System;
using UnityEngine;

namespace WeaponSystem
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] internal WeaponStatsSO weaponStats;
        [SerializeField] internal LayerMask detectionLayers;

        internal Action reloadAction;

        public bool hasAmmo => weaponStats.ammo > 0;

        public abstract void Shoot();

        public abstract void Aim();

        public abstract void Reload();

        public virtual void SpecialAction()
        {
            Debug.Log("Soy un arma :)");
        }

        // Para Handgun y Shotgun, implementar métodos de recarga de balas y cargador
        // Codificar que por medio del enum, cambiar el tipo de recarga, y que la accion
        // de recarga cambie. Ej. Recarga de Bullet, reloadAction = BulletReload;
        //
        // La recarga de cargador debe tener un debug de inicio y uno al final
        // La recarga de balas debe tener un debug por cada bala que se recarga
        //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        // Nota: No se debe pasar la municion del magazine size, y solo debe poder
        // recargar si la municion actual no esta en su máximo
        // Para esto, modificar la municion en el inspector para que sea menor al máximo o igual

        public virtual void MagazineReload()
        {
            Debug.Log("Recargando...");
            Debug.Log("...Recarga completa.");
        }

        public virtual void BulletReload()
        {
            Debug.Log("Recargado una bala.");
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
                if (Physics.Raycast(cameraRay, out hit, 20f, detectionLayers))
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
}
