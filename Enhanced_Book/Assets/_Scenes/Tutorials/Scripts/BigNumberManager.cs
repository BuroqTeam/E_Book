using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class BigNumberManager : MonoBehaviour
{
    public GameObject Dot;
    public TMP_Text Title;
    public TMP_Text Distance1;
    public TMP_Text Distance2;
    public TMP_Text Distance3;
    public TMP_Text Distance4;

    public GameObject Earth;
    public GameObject Moon;
    public GameObject Rocket;
    public GameObject Sun;

    public List<AudioClip> SoundClips = new List<AudioClip>();

    AudioSource _audioSource;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartAction());        
    }


    IEnumerator StartAction()
    {
        Title.GetComponent<RectTransform>().DOScale(1, 2);
        yield return new WaitForSeconds(1);
        _audioSource.PlayOneShot(SoundClips[0]);
        yield return new WaitForSeconds(SoundClips[0].length);
        yield return new WaitForSeconds(1);
        Title.GetComponent<RectTransform>().DOScale(0, 1);
        yield return new WaitForSeconds(2);

        Earth.transform.DOScale(1.2f, 1).OnComplete(MoonMaximize);
        _audioSource.PlayOneShot(SoundClips[1]);
        yield return new WaitForSeconds(SoundClips[1].length);
        
        Rocket.transform.DOScale(0.5f, 0);
        _audioSource.PlayOneShot(SoundClips[2]);        
        Rocket.transform.DOMove(Moon.transform.position, 5);
        StartCoroutine(CreateDot());
        yield return new WaitForSeconds(5);
        Rocket.transform.DOScale(0, 0);

        Distance1.GetComponent<RectTransform>().DOScale(1, 1);
        Distance2.GetComponent<RectTransform>().DOScale(1, 1);
        Distance3.GetComponent<RectTransform>().DOScale(1, 1);
        Distance4.GetComponent<RectTransform>().DOScale(1, 1);
        _audioSource.PlayOneShot(SoundClips[3]);
        yield return new WaitForSeconds(3);
        Distance1.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0),1, 5, 1);
        yield return new WaitForSeconds(1.1f);
        Distance2.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 5, 1);
        yield return new WaitForSeconds(1.7f);
        Distance3.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.75f, 5, 1);





    }

    void MoonMaximize()
    {
        Moon.transform.DOScale(1, 1);
    }

    IEnumerator CreateDot()
    {
        float waiting = 0.1f;
        for (int i = 0; i < 50; i++)
        {
            Instantiate(Dot, Rocket.transform.GetChild(0).position, Quaternion.identity);
            if (i < 20)
            {
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                waiting += 0.02f;
                yield return new WaitForSeconds(waiting);
            }            
        }
    }



}
