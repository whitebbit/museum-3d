
using UnityEngine;

public class OverlapDetector
{
    private readonly OverlapConfig _config;
    private readonly Transform _startPoint;
    private readonly Collider[] _overlapResults = new Collider[32];
    private int _overlapResultsCount;
    
    public OverlapDetector(OverlapConfig config,  Transform startPoint)
    {
        _config = config;
        _startPoint = startPoint;
    }

    public bool Detected()
    {
        var position = _startPoint.TransformPoint(_config.Offset);
        _overlapResultsCount = OverlapSphere(position);
        return _overlapResultsCount > 0;
    }
    
    public T GetDetectedObject<T>()
    {
        for (int i = 0; i < _overlapResultsCount; i++)
        {
            if (_overlapResults[i].TryGetComponent(out T obj))
            {
                return obj;
            }
        }
        return default;
    }
    
    public void DrawGizmos()
    {
        if (_startPoint == null)
            return;

        Gizmos.matrix = _startPoint.localToWorldMatrix;
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(_config.Offset, _config.Radius); 
    }
    
    private int OverlapSphere(Vector3 position)
    {
        return Physics.OverlapSphereNonAlloc(position, _config.Radius, _overlapResults, _config.SearchingLayerMask.value);
    }
    
}