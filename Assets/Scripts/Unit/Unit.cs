using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected UnitConfig config;
    public UnitConfig Config => config;

}
