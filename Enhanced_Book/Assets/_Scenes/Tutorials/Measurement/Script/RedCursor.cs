using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Media3_Fathulloh
{
    public class RedCursor : MonoBehaviour
    {
        public List<Vector2> PositionsHigh;
        public List<Vector2> PositionsLower;

        public Measurement MeasurementManager;



        void Start()
        {

        }

        
        public void MoveByPositions()
        {
            StartCoroutine(Moving());
        }


        IEnumerator Moving()
        {
            float time = 1.0f;
            float longTime = 1.8f;

            yield return new WaitForSeconds(2.0f);
            gameObject.GetComponent<Image>().DOFade(1, time);
            //gameObject.GetComponent<RectTransform>().DOAnchorPos(PositionsHigh[0], time);
            yield return new WaitForSeconds(longTime);
            gameObject.GetComponent<RectTransform>().DOAnchorPos(PositionsHigh[1], time);
            yield return new WaitForSeconds(longTime);
            gameObject.GetComponent<RectTransform>().DOAnchorPos(PositionsHigh[2], time);
            yield return new WaitForSeconds(2 * longTime);

            gameObject.GetComponent<Image>().DOFade(0, time);
            yield return new WaitForSeconds(1 * longTime);
            gameObject.GetComponent<RectTransform>().DOAnchorPos(PositionsLower[0], time);
            MeasurementManager.PlayAudio();   //    for audio 08

            yield return new WaitForSeconds(2 * longTime);
            gameObject.GetComponent<Image>().DOFade(1, time);
            yield return new WaitForSeconds(longTime);
            gameObject.GetComponent<RectTransform>().DOAnchorPos(PositionsLower[1], time);
            yield return new WaitForSeconds(longTime + 0.2f);
            gameObject.GetComponent<RectTransform>().DOAnchorPos(PositionsLower[2], time);
            yield return new WaitForSeconds(1.5f * longTime);
            gameObject.GetComponent<Image>().DOFade(0, time);
            yield return new WaitForSeconds(0.5f * longTime);

            StartCoroutine(MeasurementManager.ShowQisqartmalar());
        }


    }
}
