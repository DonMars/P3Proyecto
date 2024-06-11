using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private float spread;
    [SerializeField] private float pellets;

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
