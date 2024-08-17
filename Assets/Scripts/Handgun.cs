using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace WeaponSystem
{
    public class Handgun : Weapon
    {
        [SerializeField] internal ReloadTypeEnum reloadType;
        [SerializeField] internal int bulletPerReload;
        [SerializeField] internal float reloadRate;

        Transform shootCam;
        private RaycastHit hit;

        private void Awake()
        {
            shootCam = FindObjectOfType<FirstPersonController>().GetComponentInChildren<Camera>().transform;
        }

        public override void Aim()
        {

        }

        public override void Shoot()
        {
            if (hasAmmo)
            {
                FindObjectOfType<WeaponHandler>().disparoSFX.Play();
                weaponStats.ammo--;
                Debug.Log("Disparo de pistola");

                if (Physics.Raycast(shootCam.position, shootCam.forward, out hit))
                {
                    if (hit.transform.GetComponent<Health>() != null)
                        hit.transform.GetComponent<Health>().Damage(weaponStats.damage);
                }
            }
            else
            {
                Debug.Log("No tienes municion");
            }
        }

        public override void Reload()
        {
            Debug.Log("RELOAD");
        }
    }
}