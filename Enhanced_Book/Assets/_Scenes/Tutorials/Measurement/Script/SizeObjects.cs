using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Media3_Fathulloh
{
    public class SizeObjects : MonoBehaviour
    {
        public string Size;
        public Color InitialColor;
        public Color newColor;

        void Start()
        {
            InitialColor = GetComponent<TMP_Text>().color;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeText()
        {
            StartCoroutine(ChangeTextAnim());

        }


        IEnumerator ChangeTextAnim()
        {
            gameObject.GetComponent<TMP_Text>().DOFade(0, 0.5f);
            yield return new WaitForSeconds(0.75f);

            gameObject.GetComponent<TMP_Text>().text = Size;
            gameObject.GetComponent<TMP_Text>().DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.75f);
        }


        public void ChangeColor()
        {
            StartCoroutine(ShowText());
        }


        IEnumerator ShowText()
        {
            gameObject.GetComponent<TMP_Text>().DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.75f);
        }
        

        public void InvisibleColor()
        {
            gameObject.GetComponent<TMP_Text>().DOFade(0, 0.5f);
        }

    }
}
