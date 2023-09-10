
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Exhibit: MonoBehaviour, IInteractive
{
    [SerializeField] protected ExhibitConfig config;
    
    public abstract void Interact();
}
