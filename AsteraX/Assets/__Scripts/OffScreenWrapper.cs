using UnityEngine;

public class OffScreenWrapper : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(!enabled){return;}

        ScreenBounds bounds = ScreenBounds.Instance;

        //only react to leaving the screen bounds, not any other trigger
        if (other != bounds.BoundsCollider){return;}

        //wrap screen
        transform.position = bounds.WrapPosition(transform.position);
    }
}
