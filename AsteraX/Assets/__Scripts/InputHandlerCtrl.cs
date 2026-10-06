#define USE_CrossPlatformInput

using System;
using UnityEngine;

#if USE_CrossPlatformInput
using UnityStandardAssets.CrossPlatformInput;
#endif

public class InputHandlerCtrl : Singleton<InputHandlerCtrl>
{
    public float HorizontalAxis
    {
        get
        {
#if USE_CrossPlatformInput
            return CrossPlatformInputManager.GetAxis("Horizontal");
#endif
        }
    }

    public float VerticalAxis
    {
        get
        {
#if USE_CrossPlatformInput
            return CrossPlatformInputManager.GetAxis("Vertical");
#endif
        }
    }
    
    public float MouseXAxis
    {
        get
        {
#if USE_CrossPlatformInput
            return CrossPlatformInputManager.GetAxis("Mouse X");
#endif
        }
    }

    public float MouseYAxis
    {
        get
        {
#if USE_CrossPlatformInput
            return CrossPlatformInputManager.GetAxis("Mouse Y");
#endif                
        }
    }

    public float MouseScrollWheel
    {
        get
        {
#if USE_CrossPlatformInput
            return CrossPlatformInputManager.GetAxis("Mouse ScrollWheel");
#endif
        }
    }

    public Vector3 MousePosition
    {
        get
        {
#if USE_CrossPlatformInput
            return CrossPlatformInputManager.mousePosition;
#endif
        }
    }

    public bool Fire1Down
    {
        get
        {
#if USE_CrossPlatformInput            
            return CrossPlatformInputManager.GetButtonDown("Fire1");
#endif
            
            //return Input.GetButtonDown("Fire1");
        }
    }
}