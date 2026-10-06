using UnityEngine;

public class BaseTransformCtrl : MonoBehaviour
{
    [SerializeField] protected Transform _transform;
    
    protected virtual void Reset()
    {
        _transform = GetComponent<Transform>();
    }
}