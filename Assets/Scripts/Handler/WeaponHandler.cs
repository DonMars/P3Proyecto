using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{

    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] internal Weapon[] weapons;
        [SerializeField] internal Weapon currentWeapon;
        [SerializeField] internal int actualWeaponIndex = 0;

        public AudioSource disparoSFX;

        private void Start()
        {
            currentWeapon = weapons[actualWeaponIndex];
            Debug.Log("Current weapon has ammo? " + (currentWeapon.hasAmmo ? "Yes" : "No"));
        }

        private void Update()
        {
            SwitchWeapon();
            ShootInput();
            //SpecialActionInput();
        }

        private void ShootInput()
        {
            if (InputHandler.ShootInput() && currentWeapon.hasAmmo)
            {
                currentWeapon.Shoot();
            }
        }

        private void AimInput()
        {
            if (InputHandler.AimInput())
            {
                currentWeapon.Aim();
            }
        }

        private void ReloadInput()
        {
            if (InputHandler.ReloadInput())
            {
                currentWeapon.Reload();
            }
        }

        private void SpecialActionInput()
        {
            if (InputHandler.SpecialActionInput())
            {
                currentWeapon.SpecialAction();
            }
        }

        private void SwitchWeapon()
        {
            if (InputHandler.MouseScroll() > 0)
                actualWeaponIndex = actualWeaponIndex >= weapons.Length - 1 ? 0 : actualWeaponIndex + 1;
            else if (InputHandler.MouseScroll() < 0)
                actualWeaponIndex = actualWeaponIndex <= 0 ? weapons.Length - 1 : actualWeaponIndex - 1;
            else
                return;

            currentWeapon = weapons[actualWeaponIndex];
        }
    }
}