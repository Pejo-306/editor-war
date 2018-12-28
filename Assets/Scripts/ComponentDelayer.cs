using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDelayer : MonoBehaviour 
{
    public float delayTime = 1f;
    public Behaviour[] componentsToDelay;

    void Awake()
    {
        DisableComponents();
        Invoke("EnableComponents", delayTime);
    }

    private void DisableComponents()
    {
        foreach (var component in componentsToDelay)
        {
            component.enabled = false;
        }
    }

    private void EnableComponents()
    {
        foreach (var component in componentsToDelay)
        {
            component.enabled = true;
        }
    }
}

