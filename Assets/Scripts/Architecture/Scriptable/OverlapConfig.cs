using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Source/Detecting/OverlapConfig", fileName = "OverlapConfig", order = 0)]
public class OverlapConfig: ScriptableObject
{
    [Header("Masks")]
    [SerializeField] private LayerMask searchLayerMask;
    
    [Header("Overlap Area")]
    [SerializeField] private Vector3 offset;
    [SerializeField, Min(0f)] private float radius;


    public LayerMask SearchingLayerMask => searchLayerMask;
    public Vector3 Offset => offset;
    public float Radius => radius;
}
