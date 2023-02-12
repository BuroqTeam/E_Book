using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class FirstMedia : MonoBehaviour
{
    public List<AudioClip> SoundClips = new List<AudioClip>();
    AudioSource _audioSource;
    int _soundIndex = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartAction());
    }

    IEnumerator StartAction()
    {
        yield return new WaitForSeconds(1);
        PlaySound();      // for audio 01 
    }


    void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
    }
}
