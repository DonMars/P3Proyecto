using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{

    public class Shotgun : Weapon
    {
        // Se agregó este enum a Shotgun y a Handgun
        [SerializeField] internal ReloadTypeEnum reloadType;
        [SerializeField] internal int bulletPerReload;
        [SerializeField] internal float reloadRate;

        [SerializeField] internal float spread;
        [SerializeField] internal float pellets;

        public override void Aim()
        {

        }

        public override void Shoot()
        {

        }

        public override void Reload()
        {

        }

        public override void SpecialAction()
        {
            Debug.Log("CHANGOSS!");
        }
    }
}