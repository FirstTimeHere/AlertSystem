using System;
using UnityEngine;

[RequireComponent(typeof(AlarmSystem))]
public class Home : MonoBehaviour
{
    public event  Action SystemTriggerd;
    public event  Action SystemDeactivaed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject)
        {
            SystemTriggerd?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject)
        {
            SystemDeactivaed?.Invoke();
        }
    }
}
