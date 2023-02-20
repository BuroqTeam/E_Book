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
    public GameObject Rocket;
    public GameObject Doors;
    public GameObject MainBackground;
    public GameObject ControlForMill;
    public GameObject ControlForYuz;
    public GameObject Numbers;
    public GameObject NumberUnits;
    public GameObject NumberUnitsFull;
    public Sprite ActiceControl;
    public Sprite UnActiceControl;
    public Sprite Door2;
    public TMP_Text FinishText;



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
        Sun.GetComponent<RotateAround>().enabled = false;
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
        Doors.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = " ";
        Doors.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = " ";
        Doors.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Door2;
        Doors.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Door2;
        yield return new WaitForSeconds(0.8f);
        Doors.transform.GetChild(0).transform.DOMoveX(-7f, 0.8f);
        Doors.transform.GetChild(1).transform.DOMoveX(-2.8f, 0.8f);
        yield return new WaitForSeconds(1f);
        Numbers.transform.DOScale(1.5f, 1);
        Doors.transform.DOMoveX(4.18f, 1);
        Doors.transform.DOMoveZ(5f, 1);
        Doors.transform.DOScale(1.86f, 1);
        MainBackground.transform.DOScale(1.8f, 1);
        Numbers.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        PlaySound();
        yield return new WaitForSeconds(5f);
        NumberUnits.gameObject.SetActive(true);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(-2.77f, 0.5f);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(2.77f, 0.5f);
        Numbers.transform.DOMoveY(-0.7f, 0.5f);
        NumberUnits.transform.DOMoveZ(-10f, 0);
        NumberUnits.transform.DOMoveY(1f, 0.5f);
        yield return new WaitForSeconds(8.7f);


        
        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            NumberUnits.transform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            NumberUnits.transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            NumberUnits.transform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            NumberUnits.transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.04f);
        }




        yield return new WaitForSeconds(3f);
        PlaySound();
        Numbers.gameObject.SetActive(false);
        NumberUnits.gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);

        NumberUnitsFull.transform.GetChild(3).DOScale(0.4f, 1);
        for (int j = 3; j < 10; j++)
        {
            NumberUnitsFull.transform.GetChild(3).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0f);
        }
        yield return new WaitForSeconds(1f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnitsFull.transform.GetChild(3).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.03f);
        }


        NumberUnitsFull.transform.GetChild(2).DOScale(0.4f, 1);
        for (int j = 3; j < 10; j++)
        {
            NumberUnitsFull.transform.GetChild(2).GetChild(3).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0f);
        }
        yield return new WaitForSeconds(1f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnitsFull.transform.GetChild(2).GetChild(3).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.03f);
        }

        NumberUnitsFull.transform.GetChild(1).DOScale(0.4f, 1);
        for (int j = 3; j < 10; j++)
        {
            NumberUnitsFull.transform.GetChild(1).GetChild(3).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0f);
        }
        yield return new WaitForSeconds(1f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnitsFull.transform.GetChild(1).GetChild(3).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.03f);
        }

        NumberUnitsFull.transform.GetChild(0).DOScale(0.4f, 1);
        for (int j = 3; j < 10; j++)
        {
            NumberUnitsFull.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0f);
        }
        yield return new WaitForSeconds(1f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnitsFull.transform.GetChild(0).GetChild(3).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(2f);

        PlaySound();
        yield return new WaitForSeconds(1.5f);
        NumberUnitsFull.transform.GetChild(0).GetChild(1).DOMoveY(-1f, 1);
        NumberUnitsFull.transform.GetChild(1).GetChild(1).DOMoveY(-1f, 1);
        NumberUnitsFull.transform.GetChild(2).GetChild(1).DOMoveY(-1f, 1);
        NumberUnitsFull.transform.GetChild(3).GetChild(1).DOMoveY(-1f, 1);
        yield return new WaitForSeconds(5f);
        NumberUnitsFull.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        NumberUnitsFull.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        NumberUnitsFull.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        NumberUnitsFull.gameObject.SetActive(false);

        Numbers.transform.GetChild(0).GetComponent<TMP_Text>().text = "92";
        Numbers.transform.GetChild(1).GetComponent<TMP_Text>().text = "520";
        Numbers.transform.GetChild(2).GetComponent<TMP_Text>().text = "321";
        Numbers.transform.DOMoveY(-2, 0);
        Numbers.transform.DOMoveX(-4.9f, 0);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(-2.06f, 0f);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(2.06f, 0f);


        PlaySound();
        Numbers.gameObject.SetActive(true);
        NumberUnits.gameObject.SetActive(true);
        yield return new WaitForSeconds(6f);

        PlaySound();
        yield return new WaitForSeconds(1f);
        Numbers.transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Numbers.transform.GetChild(4).gameObject.SetActive(false);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(2.8f, 1f);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOAnchorPosY(1f, 1f);
        yield return new WaitForSeconds(3.5f);

        PlaySound();
        yield return new WaitForSeconds(2f);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(-3f, 1f);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOAnchorPosY(1f, 1f);
        Numbers.transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(0f, 1f);
        Numbers.transform.GetChild(1).GetComponent<RectTransform>().DOAnchorPosY(1f, 1f);
        yield return new WaitForSeconds(7.0f);

        PlaySound();
        yield return new WaitForSeconds(5.0f);


        //Sonni o'qish
        PlaySound();
        yield return new WaitForSeconds(1.0f);
        Numbers.transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        Numbers.transform.GetChild(3).gameObject.SetActive(false);

        PlaySound();
        yield return new WaitForSeconds(1.0f);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(3f);

        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2f);


        PlaySound();
        yield return new WaitForSeconds(0.7f);
        Numbers.transform.GetChild(1).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(1f);

        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }


        yield return new WaitForSeconds(0.7f);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(1f);

        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2f);


        PlaySound();
        yield return new WaitForSeconds(5f);

        PlaySound();
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(0).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);

        Numbers.transform.GetChild(1).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(1.5f);
        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(1).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);

        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Numbers.transform.GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        for (int j = 3; j < 10; j++)
        {
            NumberUnits.transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 9; j > 3; j--)
        {
            NumberUnits.transform.GetChild(2).GetChild(2).GetComponent<SpriteRenderer>().material.SetFloat("_Glow", j * 10f);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1.3f);


        PlaySound();
        yield return new WaitForSeconds(9f);
        Numbers.gameObject.SetActive(false);
        NumberUnits.gameObject.SetActive(false);
        PlaySound();
        FinishText.GetComponent<RectTransform>().DOScale(1f, 1f);

    }


    void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
    }
}
