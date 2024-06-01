using System;
using UnityEngine;

[RequireComponent(typeof(AlarmSystem))]
public class Home : MonoBehaviour
{
    public event  Action Triggerd;
    public event  Action Deactivaed;

    private void OnTriggerEnter(Collider other)
    {
        Triggerd?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Deactivaed?.Invoke();
    }
}
