using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{

    public class Handgun : Weapon
    {
        [SerializeField] internal ReloadTypeEnum reloadType;
        [SerializeField] internal int bulletPerReload;
        [SerializeField] internal float reloadRate;

        public override void Aim()
        {

        }

        public override void Shoot()
        {

        }

        public override void Reload()
        {

        }
    }
}