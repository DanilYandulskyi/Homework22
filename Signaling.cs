using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume(float finalVolume)
    {
        StartCoroutine(ChangingingVolume(finalVolume));
    }

    public void Play()
    {
        _audioSource.Play();
        ChangeVolume(1);
    }

    public void Stop()
    {
        StopAllCoroutines();
        ChangeVolume(0);
    }

    private IEnumerator ChangingingVolume(float finalVolume)
    {
        while (_audioSource.volume != finalVolume)
        {
            float maxDelta = 0.001f;

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, finalVolume, maxDelta);

            yield return new WaitForEndOfFrame();
        }
    }
}
