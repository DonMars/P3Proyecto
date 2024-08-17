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

    //    private Ray cameraRay;

    //    private void Update()
    //    {
    //        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    }

    //    public RaycastHit hit;
       
    //#if UNITY_EDITOR
    //    [ExecuteInEditMode]
    //    private void OnDrawGizmos()
    //    {
    //        Gizmos.color = Color.blue;
    //        Gizmos.DrawRay(cameraRay.origin, cameraRay.direction * 20f);
    //    }
    //#endif
        #endregion
    }
}
