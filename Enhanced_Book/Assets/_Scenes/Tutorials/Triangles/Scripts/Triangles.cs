using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Triangles : MonoBehaviour
{
    public TMP_Text Title;
    public TMP_Text Triangle;
    public TMP_Text Defination;
    public TMP_Text ForTriangle2;

    public GameObject TrianglesBackground;
    public GameObject TriangleMain;
    public GameObject Triangle2;
    public GameObject Angles;



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

        Triangle.GetComponent<RectTransform>().DOScale(1, 0.5f);
        PlaySound();
        yield return new WaitForSeconds(0.5f);
        TrianglesBackground.SetActive(true);
        Triangle.GetComponent<TMP_Text>().text = Triangle.GetComponent<TMP_Text>().text + ":";
        Triangle.GetComponent<RectTransform>().DOAnchorPosX(-150, 1.5f);
        yield return new WaitForSeconds(0.5f);
        Defination.GetComponent<RectTransform>().DOAnchorPosX(30, 0.5f);
        Defination.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 0), 0.5f);
        yield return new WaitForSeconds(1f);
        TriangleMain.GetComponent<RectTransform>().DOScale(1.5f, 1.5f);
        yield return new WaitForSeconds(1.2f);
        TriangleMain.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        TriangleMain.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        TriangleMain.GetComponent<RectTransform>().DOScale(0.5f, 1);
        TriangleMain.transform.GetChild(1).gameObject.SetActive(false);
        TriangleMain.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        TrianglesBackground.GetComponent<RectTransform>().DOScale(0, 0.1f);
        Defination.GetComponent<RectTransform>().DOScale(0, 0.1f);
        Triangle.GetComponent<RectTransform>().DOScale(0, 0.1f);



        PlaySound();
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
            Triangle2.transform.GetChild(3).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.5f);
            yield return new WaitForSeconds(0.2f);
            Triangle2.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.5f);
            Triangle2.transform.GetChild(3).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(1).GetChild(i).GetComponent<Image>().DOFillAmount(1, 1);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1.4f, 0.5f);
            yield return new WaitForSeconds(0.6f);
            Triangle2.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.5f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(1).GetChild(i).GetComponent<Image>().color = new Color32(0, 200, 80, 255);
            yield return new WaitForSeconds(1.7f);
            Triangle2.transform.GetChild(1).GetChild(i).GetComponent<Image>().color = new Color32(61, 66, 91, 255);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(1.2f);
        }
        yield return new WaitForSeconds(2.5f);




        PlaySound();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(1).GetChild(i).GetComponent<Image>().color = new Color32(0, 200, 80, 255);
            yield return new WaitForSeconds(1.5f);
        }
        Triangle2.transform.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Triangle2.transform.GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(1).GetChild(i).GetComponent<Image>().color = new Color32(61, 66, 91, 255);
        }
        yield return new WaitForSeconds(0.5f);
        Triangle2.GetComponent<RectTransform>().DOAnchorPosX(-130, 0.5f);
        yield return new WaitForSeconds(1.5f);
        ForTriangle2.GetComponent<TMP_Text>().text = ForTriangle2.GetComponent<TMP_Text>().text + "P = ";
        yield return new WaitForSeconds(1f);
        ForTriangle2.GetComponent<TMP_Text>().text = ForTriangle2.GetComponent<TMP_Text>().text + "AB";
        yield return new WaitForSeconds(1f);
        ForTriangle2.GetComponent<TMP_Text>().text = ForTriangle2.GetComponent<TMP_Text>().text + " + ";
        yield return new WaitForSeconds(1f);
        ForTriangle2.GetComponent<TMP_Text>().text = ForTriangle2.GetComponent<TMP_Text>().text + "BC";
        yield return new WaitForSeconds(1f);
        ForTriangle2.GetComponent<TMP_Text>().text = ForTriangle2.GetComponent<TMP_Text>().text + " + ";
        yield return new WaitForSeconds(1f);
        ForTriangle2.GetComponent<TMP_Text>().text = ForTriangle2.GetComponent<TMP_Text>().text + "AC";
        yield return new WaitForSeconds(1f);




        PlaySound();
        yield return new WaitForSeconds(1f);
        Angles.transform.gameObject.SetActive(true);
        Angles.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        for (int i = 0; i < 3; i++)
        {
            Angles.transform.GetChild(1).GetChild(i).GetComponent<RectTransform>().DOScale(1.4f, 0.3f);
            yield return new WaitForSeconds(0.3f);
            Angles.transform.GetChild(1).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        }
        for (int i = 0; i < 3; i++)
        {
            Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1.4f, 0.3f);
            yield return new WaitForSeconds(0.3f);
            Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        }
        yield return new WaitForSeconds(2f);



        PlaySound();
        yield return new WaitForSeconds(1f);
        Angles.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        for (int i = 1; i < 3; i++)
        {
            Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().localPosition.x + 15, 1f);
        }
        yield return new WaitForSeconds(6f);
        Angles.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        for (int i = 1; i < 3; i++)
        {
            Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().localPosition.x - 15 , 1f);
        }



        PlaySound();
        yield return new WaitForSeconds(1f);
        Angles.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().localPosition.x + 15, 1f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().localPosition.x - 15, 1f);
        yield return new WaitForSeconds(7f);
        Angles.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().localPosition.x - 15, 1f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().localPosition.x + 15, 1f);





        PlaySound();
        yield return new WaitForSeconds(1f);
        Angles.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        for (int i = 0; i < 2; i++)
        {
            Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().localPosition.x - 15, 1f);
        }
        yield return new WaitForSeconds(5f);
        Angles.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        for (int i = 0; i < 2; i++)
        {
            Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOAnchorPosX(Angles.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().localPosition.x + 15, 1f);
        }











    }

    void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
    }
}
