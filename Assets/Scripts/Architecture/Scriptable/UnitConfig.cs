using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Source/Units/UnitConfig", fileName = "UnitConfig", order = 0)]
public class UnitConfig : ScriptableObject
{
    [Header("Common"), Space] 
    [SerializeField, Min(0)] private float speed;
    
    public float Speed => speed;
}
