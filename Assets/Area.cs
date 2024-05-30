using System;
using UnityEngine;

[Serializable]
public struct Area
{
    public string areaName;
    public bool isOpen; // Indica si el area está desbloqueada
    public Transform[] spawns; // Los spawns que se encuentran en dicha area
    public GameObject[] doors; // Las puertas que colindan el area
}