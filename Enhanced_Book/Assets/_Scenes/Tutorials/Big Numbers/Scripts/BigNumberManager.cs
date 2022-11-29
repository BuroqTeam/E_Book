using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BigNumberManager : MonoBehaviour
{
    public GameObject Arrow_2;
    public GameObject Arrow;
    public GameObject Numbers;
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line3;

    public GameObject Sinflar;
    public GameObject Board_1;
    public GameObject Board_2;
    public GameObject Board_3;

    public GameObject Astronaut_1;
    public GameObject Astronaut_2;
    public GameObject Astronaut_3;

    public GameObject Dot;
    public TMP_Text Title;
    public TMP_Text Distance1;
    public TMP_Text Distance2;
    public TMP_Text Distance3;
    public TMP_Text Distance4;
    public GameObject SunDistance;
    public GameObject Earth;
    public GameObject Moon;
    public GameObject Rocket;
    public GameObject Sun;

    public List<AudioClip> SoundClips = new List<AudioClip>();

    AudioSource _audioSource;
    int _soundIndex = 0;
    List<GameObject> _dots = new List<GameObject>();


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartAction());        
    }


    IEnumerator StartAction()
    {        
        Title.GetComponent<RectTransform>().DOScale(1, 2);
        yield return new WaitForSeconds(1);
        PlaySound();

        yield return new WaitForSeconds(SoundClips[0].length);
        yield return new WaitForSeconds(1);
        Title.GetComponent<RectTransform>().DOScale(0, 1);
        yield return new WaitForSeconds(2);

        Earth.transform.DOScale(1.2f, 1).OnComplete(MoonMaximize);
        PlaySound();
        yield return new WaitForSeconds(SoundClips[1].length);
        
        Rocket.transform.DOScale(0.5f, 0);
        PlaySound();
        Rocket.transform.DOMove(Moon.transform.position, 5);
        StartCoroutine(CreateDot());
        yield return new WaitForSeconds(5);
        Rocket.transform.DOScale(0, 0);

        Distance1.GetComponent<RectTransform>().DOScale(1, 1);
        Distance2.GetComponent<RectTransform>().DOScale(1, 1);
        Distance3.GetComponent<RectTransform>().DOScale(1, 1);
        Distance4.GetComponent<RectTransform>().DOScale(1, 1);
        PlaySound();
        yield return new WaitForSeconds(3);
        Distance1.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0),1, 3, 1);
        yield return new WaitForSeconds(1.1f);
        Distance2.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 3, 1);
        yield return new WaitForSeconds(1.7f);
        Distance3.GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.75f, 3, 1);
        yield return new WaitForSeconds(4);
        PlaySound();
        Sun.transform.DOScale(5, 0);
        RemoveAll(_dots);
        Distance1.text = "";
        Distance2.text = "";
        Distance3.text = "";
        Distance4.text = "";
        Moon.transform.DOScale(0.5f, 1);
        Earth.transform.DOScale(0.7f, 1);

        yield return new WaitForSeconds(4);
        Sun.transform.DOScale(1, 3);
        Moon.transform.DOMoveY(Moon.transform.position.y - 3.5f, 2);
        Earth.transform.DOMoveX(Moon.transform.position.x, 2);
        yield return new WaitForSeconds(2);
        Rocket.transform.DOMove(Earth.transform.position, 0);
        Rocket.transform.DORotate(new Vector3(0, 0, 50), 0);
        Rocket.transform.DOScale(0.6f, 0);
        Rocket.transform.DOMove(Sun.transform.position, 5);
        StartCoroutine(CreateDot());
        yield return new WaitForSeconds(3);
        PlaySound();
        StartCoroutine(AnimateNumbers(SunDistance));
        yield return new WaitForSeconds(13);
        PlaySound();
        yield return new WaitForSeconds(5);
        Rocket.transform.DOScale(0, 0);
        Earth.transform.DOScale(0, 0);
        Sun.transform.DOScale(0, 0);
        Moon.transform.DOScale(0, 0);
        RemoveAll(_dots);
        SunDistance.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        SunDistance.transform.GetChild(1).GetComponent<TMP_Text>().text = "";
        SunDistance.transform.GetChild(2).GetComponent<TMP_Text>().text = "";
        SunDistance.transform.GetChild(3).GetComponent<TMP_Text>().text = "";
        PlaySound();        
        Astronaut_1.transform.DOScale(0.7f, 2.5f);
        yield return new WaitForSeconds(2.5f);
        Astronaut_2.transform.DOScale(0.8f, 2.5f);
        yield return new WaitForSeconds(2.5f);
        Astronaut_3.transform.DOScale(0.9f, 2.5f);
        yield return new WaitForSeconds(2.5f);

        Astronaut_1.transform.DOPunchRotation(new Vector3(0, 0, 20), 3, 3, 1);
        Astronaut_2.transform.DOPunchRotation(new Vector3(0, 0, 20), 3, 3, 1);
        Astronaut_3.transform.DOPunchRotation(new Vector3(0, 0, 20), 3, 3, 1);
        yield return new WaitForSeconds(3);
        Board_1.transform.DOScale(new Vector3(0.7f, 0.6f, 0), 1);
        Board_2.transform.DOScale(new Vector3(0.7f, 0.6f, 0), 1);
        Board_3.transform.DOScale(new Vector3(0.7f, 0.6f, 0), 1);
        yield return new WaitForSeconds(1);

        GameObject numberBoard_1 = Astronaut_1.transform.GetChild(0).gameObject;
        GameObject numberBoard_2 = Astronaut_2.transform.GetChild(0).gameObject;
        GameObject numberBoard_3 = Astronaut_3.transform.GetChild(0).gameObject;

        Astronaut_1.transform.DOScale(0, 1);
        Astronaut_2.transform.DOScale(0, 1);
        Astronaut_3.transform.DOScale(0, 1);
        numberBoard_1.transform.SetParent(null);
        numberBoard_2.transform.SetParent(null); 
        numberBoard_3.transform.SetParent(null);

        numberBoard_1.transform.DOMove(new Vector3(Board_1.transform.position.x, Board_1.transform.position.y - 1.2f, 0), 3);
        numberBoard_2.transform.DOMove(new Vector3(Board_2.transform.position.x, Board_2.transform.position.y - 1.2f, 0), 3);
        numberBoard_3.transform.DOMove(new Vector3(Board_3.transform.position.x, Board_3.transform.position.y - 1.2f, 0), 3);

        yield return new WaitForSeconds(6);
        PlaySound();

        Board_1.transform.DOScale(0, 0);
        Board_2.transform.DOScale(0, 0);
        Board_3.transform.DOScale(0, 0);

        numberBoard_1.transform.DOScale(0, 0);
        numberBoard_2.transform.DOScale(0, 0);
        numberBoard_3.transform.DOScale(0, 0);


        yield return new WaitForSeconds(4);
        Sinflar.transform.GetChild(3).transform.DOScale(1, 2);
        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(2).transform.DOScale(1, 1);
        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(1).transform.DOScale(1, 1);
        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(0).transform.DOScale(1, 1);
        yield return new WaitForSeconds(3);    
        PlaySound();
        yield return new WaitForSeconds(1.5f);
        Sinflar.transform.GetChild(0).transform.GetChild(1).transform.DOScale(1, 2);
        Sinflar.transform.GetChild(1).transform.GetChild(1).transform.DOScale(1, 2);
        Sinflar.transform.GetChild(2).transform.GetChild(1).transform.DOScale(1, 2);
        Sinflar.transform.GetChild(3).transform.GetChild(1).transform.DOScale(1, 2);
        yield return new WaitForSeconds(2);
        Line1.transform.DOScale(1, 0.5f);
        Line2.transform.DOScale(1, 0.5f);
        Line3.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(4);
        Line1.GetComponent<Image>().DOBlendableColor(Color.green, 1);
        Line2.GetComponent<Image>().DOBlendableColor(Color.green, 1);
        Line3.GetComponent<Image>().DOBlendableColor(Color.green, 1);
        Line1.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 5, 1);
        Line2.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 5, 1);
        Line3.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 5, 1);

        yield return new WaitForSeconds(2);

        Line1.transform.DOScale(0, 1);
        Line2.transform.DOScale(0, 1);
        Line3.transform.DOScale(0, 1);

        Sinflar.transform.GetChild(0).transform.GetChild(1).transform.DOScale(0, 1);
        Sinflar.transform.GetChild(1).transform.GetChild(1).transform.DOScale(0, 1);
        Sinflar.transform.GetChild(2).transform.GetChild(1).transform.DOScale(0, 1);
        Sinflar.transform.GetChild(3).transform.GetChild(1).transform.DOScale(0, 1);


        yield return new WaitForSeconds(1);
        PlaySound();
        Numbers.transform.DOScale(1, 1);
        yield return new WaitForSeconds(7);
        PlaySound();

        Arrow.transform.DOScale(1, 0);
        Arrow.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 3, 1);
        yield return new WaitForSeconds(3);
        Arrow.transform.DOScale(0, 1);

        Sinflar.transform.GetChild(3).transform.GetComponent<Image>().DOFade(0.5f, 4);
        Numbers.transform.GetChild(2).transform.DOMove(new Vector3(Sinflar.transform.GetChild(3).transform.position.x,
            Sinflar.transform.GetChild(3).transform.position.y - 1.3f, 0), 2);
        yield return new WaitForSeconds(2);
        Numbers.transform.GetChild(2).transform.SetParent(Sinflar.transform.GetChild(3).transform);
        yield return new WaitForSeconds(5);
        PlaySound();
        Sinflar.transform.GetChild(2).transform.GetComponent<Image>().DOFade(0.5f, 3);
        Numbers.transform.GetChild(1).transform.DOMove(new Vector3(Sinflar.transform.GetChild(2).transform.position.x,
            Sinflar.transform.GetChild(2).transform.position.y - 1.3f, 0), 1);
        yield return new WaitForSeconds(1);
        Numbers.transform.GetChild(1).transform.SetParent(Sinflar.transform.GetChild(2).transform);
        yield return new WaitForSeconds(4);
       
        Sinflar.transform.GetChild(1).transform.GetComponent<Image>().DOFade(0.5f, 3);
        Numbers.transform.GetChild(0).transform.DOMove(new Vector3(Sinflar.transform.GetChild(1).transform.position.x,
            Sinflar.transform.GetChild(1).transform.position.y - 1.3f, 0), 1);
        yield return new WaitForSeconds(1);
        Numbers.transform.GetChild(0).transform.SetParent(Sinflar.transform.GetChild(1).transform);
        yield return new WaitForSeconds(3);
        PlaySound();
        Sinflar.transform.GetChild(0).DOScale(0, 1);
        yield return new WaitForSeconds(1);
        Destroy(Sinflar.transform.GetChild(0).gameObject);
        

        yield return new WaitForSeconds(4);
        Sinflar.GetComponent<RectTransform>().DOSizeDelta(new Vector2(600, 100), 1, true);
        yield return new WaitForSeconds(1);

        PlaySound();

        yield return new WaitForSeconds(1);
        
        

        Arrow_2.transform.DOScale(1, 0);
        Arrow_2.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 3, 1);
        yield return new WaitForSeconds(5);
        Arrow_2.transform.DOScale(0, 1);        
        PlaySound();

        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(0).transform.GetChild(4).
            transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0), 2, 2, 1);
        yield return new WaitForSeconds(3);

        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.DOScale(1, 0);
        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(0).transform.GetComponent<Image>().DOBlendableColor(Color.white, 3);

        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(1, 0.5f);

        yield return new WaitForSeconds(2);

        PlaySound();

        Sinflar.transform.GetChild(1).transform.GetChild(3).
            transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0), 2, 2, 1);
        yield return new WaitForSeconds(2);

        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.DOScale(1, 0);
        Sinflar.transform.GetChild(1).transform.GetComponent<Image>().DOBlendableColor(Color.white, 3);

        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(1, 0.5f);


        Sinflar.transform.GetChild(2).transform.GetChild(4).
           transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0), 2, 2, 1);
        yield return new WaitForSeconds(2);

        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.DOScale(1, 0);
        Sinflar.transform.GetChild(2).transform.GetComponent<Image>().DOBlendableColor(Color.white, 3);

        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(2);
        PlaySound();
        Sinflar.transform.GetChild(2).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0);
        Sinflar.transform.GetChild(1).transform.GetChild(2).transform.GetComponent<Image>().DOFade(0, 0);
        Sinflar.transform.GetChild(0).transform.GetChild(3).transform.GetComponent<Image>().DOFade(0, 0);
        yield return new WaitForSeconds(6);
        PlaySound();
        yield return new WaitForSeconds(1);
        Sinflar.transform.GetChild(0).transform.GetChild(4).transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        yield return new WaitForSeconds(1);
        Sinflar.transform.GetChild(0).DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(1).transform.GetChild(3).transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        yield return new WaitForSeconds(1);
        Sinflar.transform.GetChild(1).DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        yield return new WaitForSeconds(2);
        Sinflar.transform.GetChild(2).transform.GetChild(4).transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
        yield return new WaitForSeconds(1);
        Sinflar.transform.GetChild(2).DOPunchScale(new Vector3(0.2f, 0.2f, 0), 1, 2, 1);
    }


    void PlaySound()
    {
        _audioSource.PlayOneShot(SoundClips[_soundIndex]);
        _soundIndex++;
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
            GameObject dot = Instantiate(Dot, Rocket.transform.GetChild(0).position, Quaternion.identity);
            _dots.Add(dot);
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


    void RemoveAll(List<GameObject> list)
    {
        foreach (GameObject obj in list)
        {
            Destroy(obj);
        }
        list.Clear();
    }

    IEnumerator AnimateNumbers(GameObject parent)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            list.Add(parent.transform.GetChild(i).gameObject);
        }

        foreach(GameObject obj in list)
        {
            obj.GetComponent<RectTransform>().DOScale(1, 1);
        }

        yield return new WaitForSeconds(4);
        list[0].GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 3, 1);
        yield return new WaitForSeconds(2);
        list[1].GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 3, 1);
        yield return new WaitForSeconds(3);
        list[2].GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 1, 3, 1);
        yield return new WaitForSeconds(1.7f);
        //list[3].GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0.5f, 0), 0.75f, 5, 1);
       

      

    }


}


public static class RectTransformExtensions
{
    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
}

