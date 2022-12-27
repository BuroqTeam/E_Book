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
    public GameObject Sides;
    public GameObject AllTriangle;
    public GameObject PosActive;
    public GameObject BackgroundMusic;



    public List<AudioClip> SoundClips = new List<AudioClip>();


    private float _1lastPos;
    private float _2lastPos;
    private float _3lastPos;
    private Vector2 _activePos;

    AudioSource _audioSource;
    int _soundIndex = 0;

    void Start()
    {
        _1lastPos = Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().localPosition.x;
        _2lastPos = Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().localPosition.x;
        _3lastPos = Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().localPosition.x;
        _activePos = PosActive.transform.GetChild(6).GetChild(0).GetComponent<RectTransform>().localPosition;
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartAction());

    }

    IEnumerator StartAction()
    {
        Title.GetComponent<RectTransform>().DOScale(1, 2);
        yield return new WaitForSeconds(1);
        PlaySound();
        yield return new WaitForSeconds(3);
        Title.GetComponent<RectTransform>().DOScale(0, 1);
        yield return new WaitForSeconds(2);

        //Triangle.GetComponent<RectTransform>().DOScale(1, 0.5f);
        //PlaySound();
        //yield return new WaitForSeconds(0.5f);
        //TrianglesBackground.SetActive(true);
        //Triangle.GetComponent<TMP_Text>().text = Triangle.GetComponent<TMP_Text>().text + ":";
        //Triangle.GetComponent<RectTransform>().DOAnchorPosX(-150, 1.5f);
        //yield return new WaitForSeconds(0.5f);
        //Defination.GetComponent<RectTransform>().DOAnchorPosX(30, 0.5f);
        //Defination.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 0), 0.5f);
        //yield return new WaitForSeconds(1f);
        //TriangleMain.GetComponent<RectTransform>().DOScale(1.5f, 1.5f);
        //yield return new WaitForSeconds(1.2f);
        //TriangleMain.transform.GetChild(1).gameObject.SetActive(true);
        //yield return new WaitForSeconds(1.5f);
        //TriangleMain.transform.GetChild(0).gameObject.SetActive(true);
        //yield return new WaitForSeconds(1);
        //TriangleMain.GetComponent<RectTransform>().DOScale(0.5f, 1);
        //TriangleMain.transform.GetChild(1).gameObject.SetActive(false);
        //TriangleMain.transform.GetChild(0).gameObject.SetActive(false);
        //yield return new WaitForSeconds(3);
        //TrianglesBackground.GetComponent<RectTransform>().DOScale(0, 0.1f);
        //Defination.GetComponent<RectTransform>().DOScale(0, 0.1f);
        //Triangle.GetComponent<RectTransform>().DOScale(0, 0.1f);



        PlaySound();
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
            Triangle2.transform.GetChild(3).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.5f);
            yield return new WaitForSeconds(0.8f);
            Triangle2.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.5f);
            Triangle2.transform.GetChild(3).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(1).GetChild(i).GetComponent<Image>().DOFillAmount(1, 1);
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
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
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            Triangle2.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.8f);
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


        //Burchaklariga kora

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
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos + 15, 1f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos + 15, 1f);
        yield return new WaitForSeconds(7f);
        Angles.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos, 1f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos, 1f);



        PlaySound();
        yield return new WaitForSeconds(1f);
        Angles.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos + 15, 1f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos - 15, 1f);
        yield return new WaitForSeconds(6f);
        Angles.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos, 1f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos, 1f);





        PlaySound();
        yield return new WaitForSeconds(1f);
        Angles.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos - 15, 1f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos - 15, 1f);
        yield return new WaitForSeconds(1f);
        PlaySound();
        yield return new WaitForSeconds(6f);
        Angles.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Angles.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos, 1f);
        Angles.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos, 1f);
        for (int i = 0; i < 3; i++)
        {
            Angles.transform.GetChild(i).GetComponent<RectTransform>().DOScale(0f, 0.3f);
        }



        //Tomonlariga kora

        PlaySound();
        yield return new WaitForSeconds(0.5f);
        Sides.transform.gameObject.SetActive(true);
        Sides.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 3; i++)
        {
            Sides.transform.GetChild(1).GetChild(i).GetComponent<RectTransform>().DOScale(1.4f, 0.3f);
            yield return new WaitForSeconds(0.3f);
            Sides.transform.GetChild(1).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        }
        for (int i = 0; i < 3; i++)
        {
            Sides.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1.4f, 0.3f);
            yield return new WaitForSeconds(0.3f);
            Sides.transform.GetChild(2).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        }
        yield return new WaitForSeconds(2.5f);



        PlaySound();
        yield return new WaitForSeconds(1f);
        Sides.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Sides.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        Sides.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos + 15, 1f);
        Sides.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos + 15, 1f);
        yield return new WaitForSeconds(5f);
        Sides.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Sides.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Sides.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos, 1f);
        Sides.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos, 1f);



        PlaySound();
        yield return new WaitForSeconds(1f);
        Sides.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Sides.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        Sides.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos + 15, 1f);
        Sides.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos - 15, 1f);
        yield return new WaitForSeconds(5f);
        Sides.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Sides.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Sides.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(_3lastPos, 1f);
        Sides.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos, 1f);





        PlaySound();
        yield return new WaitForSeconds(1f);
        Sides.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>().DOScale(1.5f, 0.3f);
        Sides.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
        Sides.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos - 15, 1f);
        Sides.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos - 15, 1f);
        yield return new WaitForSeconds(5f);
        Sides.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Sides.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1f, 0.3f);
        Sides.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>().DOAnchorPosX(_1lastPos, 1f);
        Sides.transform.GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosX(_2lastPos, 1f);



        //Barcha Uchburchaklarni sanab o'tadi

        PlaySound();
        AllTriangle.transform.GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        AllTriangle.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        AllTriangle.transform.GetChild(1).GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 3; i++)
        {
            AllTriangle.transform.GetChild(0).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 3; i++)
        {
            AllTriangle.transform.GetChild(1).GetChild(i).GetComponent<RectTransform>().DOScale(1f, 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                AllTriangle.transform.GetChild(i).GetChild(j).GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
                yield return new WaitForSeconds(2.5f);
                AllTriangle.transform.GetChild(i).GetChild(j).GetComponent<RectTransform>().DOScale(1, 0.3f);
            }
        }




        //Ucburchaklarni takrorlab chiqadi
        
        //1
        PosActive.transform.GetComponent<RectTransform>().DOScale(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        PosActive.transform.GetChild(6).GetChild(7).GetComponent<RectTransform>().DOAnchorPos(_activePos, 0.5f);
        PlaySound();
        PosActive.transform.GetChild(6).GetChild(7).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(4f);
        for (int i = 0; i < 3; i++)
        {
            PosActive.transform.GetChild(6).GetChild(7).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.3f);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(3f);
        PosActive.transform.GetChild(6).GetChild(7).GetComponent<RectTransform>().DOScale(0, 0.5f);
        PosActive.transform.GetChild(6).GetChild(7).GetComponent<RectTransform>().DOAnchorPos(PosActive.transform.GetChild(6).GetChild(1).GetComponent<RectTransform>().localPosition, 0.5f);



        //2
        PlaySound();
        PosActive.transform.GetChild(6).GetChild(8).GetComponent<RectTransform>().DOAnchorPos(_activePos, 0.5f);
        PosActive.transform.GetChild(6).GetChild(8).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(4f);
        PosActive.transform.GetChild(6).GetChild(8).GetChild(0).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(4f);
        PosActive.transform.GetChild(6).GetChild(8).GetChild(1).GetComponent<RectTransform>().DORotate(new Vector3(0, 0, -90), 1);
        yield return new WaitForSeconds(4f);
        PosActive.transform.GetChild(6).GetChild(8).GetComponent<RectTransform>().DOAnchorPos(PosActive.transform.GetChild(6).GetChild(2).GetComponent<RectTransform>().localPosition, 0.5f);
        PosActive.transform.GetChild(6).GetChild(8).GetComponent<RectTransform>().DOScale(0, 0.5f);




        //3
        PlaySound();
        PosActive.transform.GetChild(6).GetChild(9).GetComponent<RectTransform>().DOAnchorPos(_activePos, 0.5f);
        PosActive.transform.GetChild(6).GetChild(9).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(4f);
        PosActive.transform.GetChild(6).GetChild(9).GetChild(0).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(3f);
        PosActive.transform.GetChild(6).GetChild(9).GetComponent<RectTransform>().DOAnchorPos(PosActive.transform.GetChild(6).GetChild(3).GetComponent<RectTransform>().localPosition, 0.5f);
        PosActive.transform.GetChild(6).GetChild(9).GetComponent<RectTransform>().DOScale(0, 0.5f);



        //4
        PlaySound();
        PosActive.transform.GetChild(6).GetChild(10).GetComponent<RectTransform>().DOAnchorPos(_activePos, 0.5f);
        PosActive.transform.GetChild(6).GetChild(10).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(6f);
        for (int i = 0; i < 3; i++)
        {
            PosActive.transform.GetChild(6).GetChild(10).GetChild(0).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.5f);
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < 3; i++)
        {
            PosActive.transform.GetChild(6).GetChild(10).GetChild(0).GetChild(i).GetComponent<RectTransform>().DOScale(1.4f, 0.5f);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 3; i++)
        {
            PosActive.transform.GetChild(6).GetChild(10).GetChild(0).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.5f);
        }
        yield return new WaitForSeconds(6f);
        for (int i = 0; i < 3; i++)
        {
            PosActive.transform.GetChild(6).GetChild(10).GetChild(1).GetChild(i).GetComponent<RectTransform>().DOScale(1, 0.5f);
        }
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(300, 0.5f);
        yield return new WaitForSeconds(0.5f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(0).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(1).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(2).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(1).GetComponent<RectTransform>().DOAnchorPosY(-15, 1f);
        yield return new WaitForSeconds(0.5f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(3).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(4).GetComponent<RectTransform>().DOScale(1, 1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(5).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(7f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(5).GetComponent<RectTransform>().DOScale(1.3f, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetChild(5).GetComponent<RectTransform>().DOScale(1.3f, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetComponent<RectTransform>().DOAnchorPosX(1000, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(10).GetChild(2).GetComponent<RectTransform>().DOScale(0, 0);
        PosActive.transform.GetChild(6).GetChild(10).GetComponent<RectTransform>().DOAnchorPos(PosActive.transform.GetChild(6).GetChild(4).GetComponent<RectTransform>().localPosition, 0.5f);
        PosActive.transform.GetChild(6).GetChild(10).GetComponent<RectTransform>().DOScale(0, 0.5f);
        yield return new WaitForSeconds(1f);



        //5
        PlaySound();
        PosActive.transform.GetChild(6).GetChild(11).GetComponent<RectTransform>().DOAnchorPos(_activePos, 0.5f);
        PosActive.transform.GetChild(6).GetChild(11).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(1.5f);
        PosActive.transform.GetChild(6).GetChild(11).GetChild(0).GetChild(0).GetComponent<RectTransform>().DOScale(1, 1f);
        PosActive.transform.GetChild(6).GetChild(11).GetChild(0).GetChild(1).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(1f);
        PosActive.transform.GetChild(6).GetChild(11).GetChild(1).GetChild(0).GetComponent<RectTransform>().DOScale(1, 1f);
        PosActive.transform.GetChild(6).GetChild(11).GetChild(1).GetChild(1).GetComponent<RectTransform>().DOScale(1, 1f);
        yield return new WaitForSeconds(3.5f);
        PosActive.transform.GetChild(6).GetChild(11).GetComponent<RectTransform>().DOAnchorPos(PosActive.transform.GetChild(6).GetChild(5).GetComponent<RectTransform>().localPosition, 0.5f);
        PosActive.transform.GetChild(6).GetChild(11).GetComponent<RectTransform>().DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.5f);


        //6
        PlaySound();
        PosActive.transform.GetChild(6).GetChild(12).GetComponent<RectTransform>().DOAnchorPos(_activePos, 0.5f);
        PosActive.transform.GetChild(6).GetChild(12).GetComponent<RectTransform>().DOScale(1, 0.3f);
        yield return new WaitForSeconds(20f);
        PosActive.transform.GetChild(6).GetChild(12).GetComponent<RectTransform>().DOAnchorPos(PosActive.transform.GetChild(6).GetChild(6).GetComponent<RectTransform>().localPosition, 0.5f);
        PosActive.transform.GetChild(6).GetChild(12).GetComponent<RectTransform>().DOScale(0, 0.5f);
        //BackgroundMusic.gameObject.SetActive(false);
        PlaySound();


    }

    void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
    }
}
