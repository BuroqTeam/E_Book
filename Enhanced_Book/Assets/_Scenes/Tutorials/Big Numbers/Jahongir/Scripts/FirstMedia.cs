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

    [Header("Objects of Rocket")]
    public GameObject Doors;
    public GameObject MainBackground;

    [Header("Objects of Galaxy")]
    public GameObject ObjectOfGalaxy;
    public GameObject Earth;
    public GameObject Moon;
    public GameObject Sun;
    public GameObject FioSphera;
    public GameObject RedSphera;
    public GameObject GreenSphera;
    public GameObject GalaxyBackground;
    public GameObject LineForSun;
    public GameObject TextForSun;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartAction());
    }

    IEnumerator StartAction()
    {
        //Door yopilib Mavzning nomi aytilishi
        yield return new WaitForSeconds(1f);
        Doors.transform.GetChild(0).transform.DOMoveX(-7f, 0.8f);
        Doors.transform.GetChild(1).transform.DOMoveX(-2.8f, 0.8f);

        PlaySound();
        
        yield return new WaitForSeconds(4f);
        Doors.transform.GetChild(0).transform.DOMoveX(-20f, 2f);
        Doors.transform.GetChild(1).transform.DOMoveX(12f, 2f);
        yield return new WaitForSeconds(1f);
        MainBackground.transform.GetChild(0).transform.DOMoveY(0, 0f);

        PlaySound();
        MainBackground.transform.DOScale(1.5f, 7);
        yield return new WaitForSeconds(7f);

        //Oy va Yer o‘rtasidagi masofa
        PlaySound();
        MainBackground.transform.DOScale(3.2f, 1);
        MainBackground.transform.GetChild(0).transform.DOMoveZ(-21, 1);
        yield return new WaitForSeconds(0.8f);
        Earth.GetComponent<RotateForEarth>().enabled = false;
        Moon.GetComponent<RotateAround>().enabled = false;
        ObjectOfGalaxy.transform.DOMove(new Vector3(-45, 8, 20), 2);
        ObjectOfGalaxy.transform.DOScale(7,2);
        yield return new WaitForSeconds(3f);
        Earth.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        PlaySound();
        yield return new WaitForSeconds(2.5f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = "3";
        yield return new WaitForSeconds(0.4f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + "8";
        yield return new WaitForSeconds(0.4f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + "4";
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + " ";
        yield return new WaitForSeconds(1f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + "4";
        yield return new WaitForSeconds(0.2f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + "0";
        yield return new WaitForSeconds(0.2f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + "3";
        yield return new WaitForSeconds(0.2f);
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = Earth.transform.GetChild(2).GetComponent<TMP_Text>().text + " km";
        yield return new WaitForSeconds(2.5f);


        //Quyosh va yer orasidagi masofa
        PlaySound();
        ObjectOfGalaxy.transform.DOMove(new Vector3(-17, 3.5f, 5), 2);
        ObjectOfGalaxy.transform.DOScale(3, 2);
        yield return new WaitForSeconds(2f);
        LineForSun.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);

        PlaySound();
        yield return new WaitForSeconds(3f);
        TextForSun.GetComponent<TMP_Text>().text = "1";
        yield return new WaitForSeconds(0.3f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "4";
        yield return new WaitForSeconds(0.3f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "8";
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + " ";
        yield return new WaitForSeconds(0.5f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "8";
        yield return new WaitForSeconds(0.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "9";
        yield return new WaitForSeconds(0.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "6";
        yield return new WaitForSeconds(0.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + " ";
        yield return new WaitForSeconds(1.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "5";
        yield return new WaitForSeconds(0.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "0";
        yield return new WaitForSeconds(0.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + "6";
        yield return new WaitForSeconds(0.2f);
        TextForSun.GetComponent<TMP_Text>().text = TextForSun.GetComponent<TMP_Text>().text + " km";
        yield return new WaitForSeconds(2.5f);


        //Kosmik kema ichiga kirish
        PlaySound();
        LineForSun.gameObject.SetActive(false);
        Earth.transform.GetChild(1).gameObject.SetActive(false);
        TextForSun.GetComponent<TMP_Text>().text = " ";
        Earth.transform.GetChild(2).GetComponent<TMP_Text>().text = " ";
        ObjectOfGalaxy.transform.DOMove(new Vector3(-7.44f, 1.15f, 10), 2);
        ObjectOfGalaxy.transform.DOScale(1, 2);
        yield return new WaitForSeconds(0.5f);
        MainBackground.transform.DOScale(1f, 1);
        MainBackground.transform.GetChild(0).transform.DOMoveZ(0.1f, 1);
        Earth.GetComponent<RotateForEarth>().enabled = true;
        Moon.GetComponent<RotateAround>().enabled = true;
        



    }


    void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
    }
}
