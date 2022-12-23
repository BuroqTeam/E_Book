using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Media3_Fathulloh
{
    public class Measurement : MonoBehaviour
    {
        public GameObject TitleObject;
        public GameObject MathObject;
        public GameObject SylinderObj;
        public GameObject Media3Sylinder;

        public float TitleDurration;
        public List<AudioClip> Audios;
        public Ease ChosenEase;
        public int Index;



        float distanceDurration = 0.7f;
        AudioSource audioSource;
        public GameObject MetrObjects;
        public GameObject CursorObject;
        public GameObject Qisqartmalar, QisqartmalarTextObj;
        public GameObject RotatedObject;
        public GameObject RotatedObject2;
        public GameObject StrelkaObject;
        public List<GameObject> SylinderTexts; 
        public List<GameObject> ScalenObjects;
        public List<GameObject> OtherScalens;
        public List<GameObject> TallAndShort;
        


        private void Awake()
        {
            Minimize();
        }


        void Minimize()
        {
            for (int i = 0; i < OtherScalens.Count; i++)
                OtherScalens[i].transform.DOScale(0, 0);
        }


        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(MovementText());
            //Index = 8;
            //StartCoroutine(ShowQisqartmalar());
        }

        
        void Update()
        {

        }


        public IEnumerator MovementText()
        {
            StartCoroutine(MovingObject(TitleDurration, TitleObject, new Vector3(0, 65, 0), false));
            yield return new WaitForSeconds(TitleDurration + 0.545f);

            yield return new WaitForSeconds( distanceDurration);            
            PlayAudio();  // for audio 02
            yield return new WaitForSeconds(3.7f);
            TitleObject.GetComponent<RectTransform>().DOAnchorPosY(180, 0.5f);

            StartCoroutine(ScaleSylinderObjects());            
            yield return new WaitForSeconds(13f);
            
            MinimizeObject(Media3Sylinder, 1);
            yield return new WaitForSeconds(1f);
            StartCoroutine(TollAndShortAnim());

            //SylinderObj.GetComponent<RectTransform>().DOScale(1, 0.5f)
            //    .SetEase(ChosenEase);
        }


        public IEnumerator MovingObject(float durration, GameObject obj, Vector3 vec, bool _isOut)
        {            
            yield return new WaitForSeconds(0.5f);
            //audioSource.PlayOneShot(Audios[Index]);
            //Index++;

            PlayAudio();       // for audio 01            
            yield return new WaitForSeconds(0.045f);
            obj.GetComponent<RectTransform>().DOAnchorPos(vec, durration)
                .SetEase(ChosenEase);

            yield return new WaitForSeconds(durration);
            if (_isOut)
            {
                Debug.Log(_isOut);
            }
            
        }


        IEnumerator ScaleSylinderObjects()
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < ScalenObjects.Count; i++)
            {
                ScalenObjects[i].transform.DOScale(1, 0.6f)
                    .SetEase(ChosenEase);
                yield return new WaitForSeconds(0.75f);

                if (i == 0)
                    yield return new WaitForSeconds(2f);                
            }

            yield return new WaitForSeconds(3.9f);

            for (int i = 0; i < SylinderTexts.Count; i++)            {
                SylinderTexts[i].GetComponent<SizeObjects>().ChangeText();
                //yield return new WaitForSeconds(0.75f);
            }
        }


        IEnumerator TollAndShortAnim()
        {
            float time = 0.75f;
            float littleTime = 0.5f;
            PlayAudio();  // for audio 03
            yield return new WaitForSeconds(time);
            TallAndShort[0].GetComponent<RectTransform>().DOScale(1, littleTime)
                .SetEase(ChosenEase);
            yield return new WaitForSeconds(time);
            TallAndShort[0].GetComponent<RectTransform>().DOScaleY(1.2f, littleTime);            
            yield return new WaitForSeconds(2f * time);
            TallAndShort[0].GetComponent<RectTransform>().DOScaleY(0.75f, littleTime)
                .SetEase(ChosenEase);
            yield return new WaitForSeconds(2.5f * time);

            TallAndShort[1].GetComponent<RectTransform>().DOScale(1, time)
                .SetEase(ChosenEase);
            yield return new WaitForSeconds(time);
            TallAndShort[1].GetComponent<RectTransform>().DOAnchorPosY(-75, time)
                .SetEase(ChosenEase);
            yield return new WaitForSeconds(time);
            TallAndShort[1].GetComponent<RectTransform>().DOAnchorPosY(50, time)
                .SetEase(ChosenEase);
            yield return new WaitForSeconds(3 * time);
            TallAndShort[0].GetComponent<RectTransform>().DOScale(1, littleTime);
            TallAndShort[1].GetComponent<RectTransform>().DOAnchorPosY(15, time);

            yield return new WaitForSeconds(5 * time);
            PlayAudio();    //   for audio 04
            
            yield return new WaitForSeconds(3.5f * time);
            TallAndShort[0].transform.GetChild(0).gameObject.GetComponent<SizeObjects>().ChangeColor();
            yield return new WaitForSeconds(3.5f * time);
            TallAndShort[1].transform.GetChild(0).gameObject.GetComponent<SizeObjects>().ChangeColor();

            yield return new WaitForSeconds(8.0f);
            TallAndShort[0].GetComponent<RectTransform>().DOScale(0, littleTime);
            TallAndShort[1].GetComponent<RectTransform>().DOScale(0, littleTime);
            yield return new WaitForSeconds(0.5f);
            TallAndShort[2].GetComponent<SizeObjects>().ChangeColor();
            TallAndShort[3].GetComponent<SizeObjects>().ChangeColor();

            PlayAudio();     // for audio 05

            yield return new WaitForSeconds(4.0f);
            TallAndShort[2].GetComponent<SizeObjects>().InvisibleColor();
            TallAndShort[3].GetComponent<SizeObjects>().InvisibleColor();
            yield return new WaitForSeconds(1.0f);

            PlayAudio();     // for audio 06
            StartCoroutine(MetrAnimations());

        }


        IEnumerator MetrAnimations()
        {
            float time = 0.75f;

            yield return new WaitForSeconds(1.0f);
            MetrObjects.transform.GetChild(0).GetComponent<RectTransform>().DOScale(1, time);
            yield return new WaitForSeconds(5.0f);
            MetrObjects.transform.GetChild(1).GetComponent<RectTransform>().DOScale(1, time);

            yield return new WaitForSeconds(2.0f);
            MetrObjects.transform.GetChild(2).GetComponent<RectTransform>().DOScale(1, time);
                        
            yield return new WaitForSeconds(2.0f);
            MetrObjects.transform.GetChild(3).GetComponent<RectTransform>().DOScale(1, time);

            yield return new WaitForSeconds(3.0f);
            StartCoroutine(ByPrefix());
        }


        public IEnumerator ByPrefix() 
        {
            PlayAudio();    // for audio 07
            yield return new WaitForSeconds(1.0f);
            CursorObject.GetComponent<RectTransform>().DOScale(1, 0.5f)
                .SetEase(ChosenEase);
            yield return new WaitForSeconds(1.0f);
            
            CursorObject.GetComponent<RedCursor>().MoveByPositions();
            
        }



        public Ease EaseforShorts;

        public IEnumerator ShowQisqartmalar()
        {
            float littleTime = 0.5f;
            float time = 1.0f;
            PlayAudio();   // for audio 09 
            yield return new WaitForSeconds(1.0f);
            QisqartmalarTextObj.GetComponent<SizeObjects>().ChangeColor();

            yield return new WaitForSeconds(1.0f);
            for (int i = 0; i < Qisqartmalar.transform.childCount; i += 2) 
            {
                Qisqartmalar.transform.GetChild(i).GetComponent<RectTransform>().DOScale(1, littleTime)
                    .SetEase(EaseforShorts);
                Qisqartmalar.transform.GetChild(i + 1).GetComponent<RectTransform>().DOScale(1, littleTime)
                    .SetEase(EaseforShorts);
                yield return new WaitForSeconds(littleTime);
            }
            yield return new WaitForSeconds(12.5f);
            MetrObjects.GetComponent<RectTransform>().DOAnchorPosX(-950, 1.5f);

            yield return new WaitForSeconds(2 * time);
            PlayAudio();
            RotatedObject.GetComponent<RectTransform>().DOScale(1, time);
            yield return new WaitForSeconds( 4 * time);
            RotatedObject.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 90), time);
            yield return new WaitForSeconds(4.5f*time);
            
            StrelkaObject.transform.GetChild(1).gameObject.SetActive(true);
            for (int i = 0; i < StrelkaObject.transform.GetChild(0).transform.childCount; i++)            
                StrelkaObject.transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<Image>().DOFade(1, littleTime);            

            yield return new WaitForSeconds(2.5f * time);

            StrelkaObject.transform.GetChild(1).gameObject.SetActive(false);
            for (int i = 0; i < StrelkaObject.transform.GetChild(0).transform.childCount; i++)
                StrelkaObject.transform.GetChild(0).transform.GetChild(i).gameObject.GetComponent<Image>().DOFade(0, littleTime);
            yield return new WaitForSeconds(1.2f * time);

            StrelkaObject.transform.GetChild(3).gameObject.SetActive(true);
            for (int i = 0; i < StrelkaObject.transform.GetChild(2).transform.childCount; i++)
                StrelkaObject.transform.GetChild(2).transform.GetChild(i).gameObject.GetComponent<Image>().DOFade(1, littleTime);
            yield return new WaitForSeconds(3.5f * time);

            StrelkaObject.transform.GetChild(3).gameObject.SetActive(false);
            for (int i = 0; i < StrelkaObject.transform.GetChild(2).transform.childCount; i++)
                StrelkaObject.transform.GetChild(2).transform.GetChild(i).gameObject.GetComponent<Image>().DOFade(0, littleTime);
            yield return new WaitForSeconds(2 * time);

            //yield return new WaitForSeconds(1);
            PlayAudio();
            for (int i = 0; i < RotatedObject.transform.childCount; i++)
            {
                RotatedObject.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(2.5f);
            RotatedObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = "1";
            yield return new WaitForSeconds(2);
            RotatedObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            RotatedObject.transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            RotatedObject.transform.GetChild(3).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            yield return new WaitForSeconds(1.9f);
            RotatedObject.transform.GetChild(4).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            RotatedObject.transform.GetChild(5).transform.GetChild(0).transform.GetChild(0).GetComponent<TMP_Text>().text = "0";
            yield return new WaitForSeconds(2.5f);
            RotatedObject.transform.DOScale(0, 0.5f);
            yield return new WaitForSeconds(1.5f);

            PlayAudio();
            RotatedObject2.transform.DOScale(1, 1f);
                //.SetEase(ChosenEase);
            yield return new WaitForSeconds(1.5f);

            yield return new WaitForSeconds(7.5f);
            PlayAudio();
            yield return new WaitForSeconds(1.5f);
            RotatedObject2.transform.GetChild(6).GetComponent<TMP_Text>().DOColor(new Color(0.7f, 0.01f, 0.14f), 0.5f);
            yield return new WaitForSeconds(0.6f);
            RotatedObject2.transform.GetChild(5).GetComponent<TMP_Text>().DOColor(new Color(0.7f, 0.01f, 0.14f), 0.5f);
            yield return new WaitForSeconds(0.6f);
            RotatedObject2.transform.GetChild(3).GetComponent<TMP_Text>().DOColor(new Color(0.7f, 0.01f, 0.14f), 0.5f);
            yield return new WaitForSeconds(0.6f);
            RotatedObject2.transform.GetChild(0).GetComponent<TMP_Text>().DOColor(new Color(0.7f, 0.01f, 0.14f), 0.5f);
            yield return new WaitForSeconds(1.2f);

            TheLast.transform.GetChild(0).GetComponent<TMP_Text>().DOFade(1, 0.5f);
            yield return new WaitForSeconds(1.2f);

            TheLast.transform.GetChild(2).transform.DOScale(1, 1);
            yield return new WaitForSeconds(1f);

            TheLast.transform.GetChild(1).transform.DOScale(1, 1);
            yield return new WaitForSeconds(1.2f);
            
            //TheLast.transform.GetChild(2).GetComponent<VirusAnim>().VirusAnimation();
        }

        public GameObject TheLast;

        public IEnumerator NanoMetrAnim()
        {
            yield return new WaitForSeconds(1.0f);
            PlayAudio();    // for audio 
            yield return new WaitForSeconds(1.0f);
            

        }



        public void PlayAudio()
        {
            audioSource.PlayOneShot(Audios[Index]);
            //Debug.Log(Audios[Index].name);
            Index++;
            
        }


        public void MinimizeObject(GameObject obj, float time)
        {
            obj.GetComponent<RectTransform>().DOScale(0, time);
        }



    }
}
