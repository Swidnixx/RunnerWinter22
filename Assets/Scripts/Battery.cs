using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "Battery", menuName = "Powerups/Battery")]
public class Battery : ScriptableObject
{
    [HideInInspector] 
    public bool isActive;
    public float immortalTime = 5;
    public float speedBoost = 0.1f;
}
