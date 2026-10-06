using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float bulletSpeed = 20;
    [SerializeField] private float lifeTime = 3;
    
    IEnumerator Start()
    {
        _rb.linearVelocity = transform.forward * bulletSpeed;
        
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
