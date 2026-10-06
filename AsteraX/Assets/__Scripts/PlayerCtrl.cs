using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCtrl : Singleton<PlayerCtrl>
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 1;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _projectilePrefab;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = InputHandlerCtrl.Instance.HorizontalAxis;
        float vertical = InputHandlerCtrl.Instance.VerticalAxis;
        
        Vector3 velocity = new  Vector3(horizontal, vertical);

        if (velocity.magnitude > 1f)
        {
            //Avoid speed multiplying by 1.414 when moving at a diagonal
            velocity.Normalize();
        }
        
        _rb.linearVelocity = velocity * (_speed * Time.deltaTime);

        if (InputHandlerCtrl.Instance.Fire1Down)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var mousePosition = InputHandlerCtrl.Instance.MousePosition;
        
        mousePosition.z = -_camera.transform.position.z;
        
        Vector3 pos3d = _camera.ScreenToWorldPoint(mousePosition);
        
        GameObject bullet = Instantiate(_projectilePrefab);
        bullet.transform.position = transform.position;
        bullet.transform.LookAt(pos3d);
    }
}