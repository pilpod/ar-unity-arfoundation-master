using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class DeviceCompatibility : MonoBehaviour
{

    public UnityEvent<bool> OnStateReady;

    private void Start()
    {
        StartCoroutine(StartChecking());
    }

    private IEnumerator StartChecking()
    {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            OnStateReady.Invoke(false);
        }
        else
        {
            OnStateReady.Invoke(true);
        }
    }
}
