using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Media3_Fathulloh
{
    public class VirusAnim : MonoBehaviour
    {
        float minSize = 0.85f;
        float maxSize = 1;
        float time = 1.0f;

        public bool _IsTrue;


        void Start()
        {

        }

        public void VirusAnimation()
        {
            //StartCoroutine(Minimizing());
        }

        public IEnumerator Minimizing()
        {
            gameObject.transform.DOScale(minSize, time);
            yield return new WaitForSeconds(time + 0.1f);
            gameObject.transform.DOScale(maxSize, time);
            yield return new WaitForSeconds(time + 0.1f);

            gameObject.transform.DOScale(minSize, time);
            yield return new WaitForSeconds(time + 0.1f);
            gameObject.transform.DOScale(maxSize, time);
            yield return new WaitForSeconds(time + 0.1f);
            Debug.Log("Ishladi.");
            if (_IsTrue)
            {
                StartCoroutine(Minimizing());
            }
        }
    }
}
