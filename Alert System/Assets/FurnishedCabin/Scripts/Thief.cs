using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private void Update()
    {
        if (_alarmSystem.GetVolume() == 1f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (_alarmSystem.GetVolume() == 0f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
