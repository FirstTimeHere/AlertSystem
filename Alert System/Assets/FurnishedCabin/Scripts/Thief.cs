using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarmSystem;

    private Vector3 _spawnTransform;

    private float _runSpeed = 15f;
    private float _speed = 6f;

    private bool _isAlarmNotDetected = true;

    private void Awake()
    {
        _spawnTransform = transform.position;
    }

    private void Update()
    {
        if (_isAlarmNotDetected)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * _runSpeed * Time.deltaTime);
        }

        if (_alarmSystem.GetVolume() == 1f)
        {
            _isAlarmNotDetected = false;
        }
        else if (_alarmSystem.GetVolume() == 0f)
        {
            _isAlarmNotDetected = true;
        }
    }
}
