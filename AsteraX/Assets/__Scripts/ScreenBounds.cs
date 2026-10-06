using System;
using UnityEngine;

public class ScreenBounds : Singleton<ScreenBounds>
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Camera _camera;
    
    [SerializeField] private float zScale = 10;

    private float cachedOrthographicSize;
    private float cachedAspectRatio;
    private Vector3 cachedCamScale;

    public Collider BoundsCollider => _boxCollider;

    private void Start()
    {
        _boxCollider.size = Vector3.zero;
        _boxCollider.size = Vector3.one;
        transform.position = Vector3.zero;
    }

    private void Update()
    {
        ScaleBox();
    }

    /// <summary>
    /// Mirrors every axis of a world position that lies outside the box to the opposite side,
    /// keeping the overshoot distance, so an object that just left comes back in on the far edge.
    /// </summary>
    public Vector3 WrapPosition(Vector3 worldPosition)
    {
        /*Vector3 center = _boxCollider.center;
        Vector3 halfSize = _boxCollider.size * 0.5f;
        Vector3 local = transform.InverseTransformPoint(worldPosition) - center;

        if (Mathf.Abs(local.x) > halfSize.x) { local.x = -local.x; }
        if (Mathf.Abs(local.y) > halfSize.y) { local.y = -local.y; }
        if (Mathf.Abs(local.z) > halfSize.z) { local.z = -local.z; }

        return transform.TransformPoint(local + center);*/
        
        Vector3 relativeLoc = transform.InverseTransformPoint(worldPosition);

        if (Mathf.Abs(relativeLoc.x) > 0.5f)
        {
            relativeLoc.x *= -1;
        }
        
        if (Mathf.Abs(relativeLoc.y) > 0.5f)
        {
            relativeLoc.y *= -1;
        }
        
        return transform.TransformPoint(relativeLoc);
    }

    private void ScaleBox()
    {
        if (_camera.orthographicSize.Equals(cachedOrthographicSize) || _camera.aspect.Equals(cachedAspectRatio))
        {
            return;
        }
        
        transform.localScale = CalculateBounds();
    }

    private Vector3 CalculateBounds()
    {
        cachedOrthographicSize = _camera.orthographicSize;
        cachedAspectRatio = _camera.aspect;
        
        cachedCamScale = _camera.transform.localScale;

        Vector3 scaleDesired, scaleColl;
        
        scaleDesired.z = zScale;
        scaleDesired.y = _camera.orthographicSize * 2;
        scaleDesired.x = scaleDesired.y * _camera.aspect;

        scaleColl = scaleDesired.ComponentDivide(cachedCamScale);

        //scaleColl = scaleDesired;
        
        return scaleColl;
    }
}