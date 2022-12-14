using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Magnet", menuName = "Powerups/Magnet")]
public class Magnet : ScriptableObject
{
    [HideInInspector]
    public bool isActive;
    public float duration = 5;
    public float range = 2;
    public float coinsSpeed = 2;

    public int level = 1;
    public int upgradeCost = 100;
    public Magnet upgraded;
}
