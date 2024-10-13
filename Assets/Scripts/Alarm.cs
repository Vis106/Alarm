using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip _alarm;
    [SerializeField] private AudioSource _sounds;
    [SerializeField] private float _deltaVolume = 0.5f;
    [SerializeField] private float _waitForSecondsInterval = 0.01f;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _setTargetVolume;

    public void TurnOn()
    {
        _sounds.PlayOneShot(_alarm);
        SetTargetVolume(_maxVolume, _deltaVolume, _waitForSecondsInterval);
    }

    public void TurnOf()
    {
        if (_setTargetVolume != null)
        {
            StopCoroutine(_setTargetVolume);
        }

        _setTargetVolume = StartCoroutine(TurningOffSound());
    }

    private Coroutine SetTargetVolume(float targetVolume, float deltaVolume, float waitForSecondsInterval)
    {
        if (_setTargetVolume != null)
        {
            StopCoroutine(_setTargetVolume);
        }

        return _setTargetVolume = StartCoroutine(ChangeVolume(targetVolume, deltaVolume, waitForSecondsInterval));
    }

    private IEnumerator ChangeVolume(float targetVolume, float deltaVolume, float waitForSecondsInterval)
    {
        var timeInterval = new WaitForSeconds(waitForSecondsInterval);

        while (_sounds.volume != targetVolume)
        {
            _sounds.volume = Mathf.MoveTowards(_sounds.volume, targetVolume, deltaVolume * Time.deltaTime);

            yield return timeInterval;
        }
    }

    private IEnumerator TurningOffSound()
    {
        yield return SetTargetVolume(_minVolume, _deltaVolume, _waitForSecondsInterval);

        _sounds.Stop();
    }
}