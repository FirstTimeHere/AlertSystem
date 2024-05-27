using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;
    [SerializeField] private Thief _thief;

    private AudioSource _alarmAudioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private bool _isAttacked;

    private void Awake()
    {
        _alarmAudioSource = GetComponent<AudioSource>();
        _alarmAudioSource.clip = _alarmSound;
        _alarmAudioSource.loop = true;
        _alarmAudioSource.volume = _minVolume;
    }

    private void Update()
    {
        if (_isAttacked)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _maxVolume, Time.deltaTime);
        }
        else
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, _minVolume, Time.deltaTime * 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _thief.gameObject)
        {
            _alarmAudioSource.Play();
            _isAttacked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _thief.gameObject)
        {
            _isAttacked = false;
        }
    }

    public float GetVolume()
    {
        return _alarmAudioSource.volume;
    }
}
