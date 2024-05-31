using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;

    private Home _home;

    private AudioSource _alarmAudioSource;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _reactionTimeAlarm = 2f;

    private Coroutine _reactionCoroutine;

    private void Awake()
    {
        _alarmAudioSource = GetComponent<AudioSource>();
        _home = GetComponent<Home>();

        _alarmAudioSource.clip = _alarmSound;
        _alarmAudioSource.loop = true;
        _alarmAudioSource.volume = _minVolume;
        _alarmAudioSource.enabled = false;
    }

    private void OnEnable()
    {
        _home.SystemTriggerd += OnTriggered;
        _home.SystemDeactivaed += OnDisabled;
    }

    private void OnDisable()
    {
        _home.SystemTriggerd -= OnTriggered;
        _home.SystemDeactivaed -= OnDisabled;
    }

    private void OnTriggered()
    {
        _alarmAudioSource.enabled = true;

        if (_reactionCoroutine != null)
        {
            StopCoroutine(_reactionCoroutine);
        }

        _reactionCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    private void OnDisabled()
    {
        if (_reactionCoroutine != null)
        {
            StopCoroutine(_reactionCoroutine);
        }

        _reactionCoroutine = StartCoroutine(ChangeVolume(_minVolume));

    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (volume != _alarmAudioSource.volume)
        {
            _alarmAudioSource.volume = Mathf.MoveTowards(_alarmAudioSource.volume, volume, Time.deltaTime * _reactionTimeAlarm);

            yield return null;
        }

        if (_alarmAudioSource.volume == _minVolume)
        {
            _alarmAudioSource.enabled = false;
        }
    }
}
