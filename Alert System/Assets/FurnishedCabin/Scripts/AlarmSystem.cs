using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;

    private AudioSource _alarmAudioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _reactionTimeAlarm = 3f;
    private float _reactionTimeAlarmCalmDown = 0.1f;

    private bool _isAttacked;

    private void Awake()
    {
        _alarmAudioSource = GetComponent<AudioSource>();
        _alarmAudioSource.clip = _alarmSound;
        _alarmAudioSource.loop = true;
        _alarmAudioSource.volume = _minVolume;
        _alarmAudioSource.enabled = false;
    }

    private void Update()
    {
        if (_isAttacked && _alarmAudioSource.enabled)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _maxVolume, Time.deltaTime * _reactionTimeAlarm);
        }
        else
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _minVolume, Time.deltaTime * _reactionTimeAlarmCalmDown);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            _alarmAudioSource.enabled = true;
            _alarmAudioSource.Play();
            _isAttacked = true;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject)
    //    {
    //        _alarmAudioSource.enabled = false;
    //        _isAttacked = false;
    //    }
    //}

    public float GetVolume()
    {
        return _alarmAudioSource.volume;
    }
}
