using System;
using UnityEngine;

public class TurretPointAtMouse : BaseTransformCtrl
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 mousePoint3d;
    
    private void Update()
    {
        PointAtMouse();
    }

    private void PointAtMouse()
    {
        var mousePosition = InputHandlerCtrl.Instance.MousePosition;
        
        mousePoint3d = mainCamera.ScreenToWorldPoint(mousePosition + Vector3.back * mainCamera.transform.position.z);
        
        _transform.LookAt(mousePoint3d, Vector3.back);
    }
}