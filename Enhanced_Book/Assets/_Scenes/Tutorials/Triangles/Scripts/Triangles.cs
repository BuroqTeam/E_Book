using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Triangles : MonoBehaviour
{
    public TMP_Text Title;
    public TMP_Text Triangle;
    public TMP_Text Defination;

    public List<AudioClip> SoundClips = new List<AudioClip>();

    AudioSource _audioSource;
    int _soundIndex = 0;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartAction());

    }

    IEnumerator StartAction()
    {
        Title.GetComponent<RectTransform>().DOScale(1, 2);
        yield return new WaitForSeconds(4);
        Title.GetComponent<RectTransform>().DOScale(0, 1);
        yield return new WaitForSeconds(2);

        Triangle.GetComponent<RectTransform>().DOScale(1, 2);
        PlaySound();
        yield return new WaitForSeconds(1);
        Triangle.GetComponent<RectTransform>().DOAnchorPosX(-150,2);
        Defination.GetComponent<RectTransform>().DOAnchorPosX(0, 2);
        Defination.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 0), 2);
    }

        void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
    }
}
