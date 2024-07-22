using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{

    public class AutomaticRifle : Weapon
    {
        [SerializeField] private AutomaticFireTypeEnum fireType;

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
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA!!!!!!!!!!!!!");
        }
    }
}