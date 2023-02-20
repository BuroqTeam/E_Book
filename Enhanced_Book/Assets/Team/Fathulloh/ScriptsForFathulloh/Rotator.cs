using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FathullohExample
{
    public class Rotator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public enum RotateAxis { forX, forY, forZ};
        public RotateAxis CurrentAxis;

        private int degree = 90;
        [SerializeField] private Vector3 _rotation;
        [SerializeField] private float speed = 2.0f;
        public bool _isTrue = false;        

        float durration = 0.1f;



        void Start()
        {
            ChooseAxis();
            Button btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(CliCkClassButton);
        }

        
        void Update()
        {
            if (_isTrue)
            {
                gameObject.transform.GetChild(1).transform.Rotate(_rotation * speed * Time.deltaTime);
                gameObject.transform.GetChild(0).transform.Rotate(_rotation * speed * Time.deltaTime);
            }
        }       


        public void OnPointerEnter(PointerEventData eventData)
        {
            _isTrue = true;
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            _isTrue = false;
            gameObject.transform.GetChild(1).transform.rotation = Quaternion.Euler(0, 0, 0);
            gameObject.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
            //Quaternion target = Quaternion.Euler(0, 0, 0);
            //gameObject.transform.GetChild(1).transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            //Debug.Log("LLL");
        }


        void ChooseAxis()
        {
            if (CurrentAxis == RotateAxis.forX)
            {
                _rotation = new Vector3(degree, 0, 0);
            }
            else if (CurrentAxis == RotateAxis.forY)
            {
                _rotation = new Vector3( 0, degree, 0);
            }
            else if (CurrentAxis == RotateAxis.forZ)
            {
                _rotation = new Vector3( 0, 0, degree);
            }
        }


        private void CliCkClassButton()
        {
            StartCoroutine(ArrowAnim());
        }
                

        IEnumerator ArrowAnim()
        {
            gameObject.transform.GetChild(3).gameObject.transform.DOScale(1.15f, durration);
            yield return new WaitForSeconds(durration);
            gameObject.transform.GetChild(3).gameObject.transform.DOScale(1.0f, durration);
            yield return new WaitForSeconds(durration);
        }


        //Debug.Log(Vector3.up);
        //Debug.Log(Vector3.down);
        //Debug.Log(Vector3.right);
        //Debug.Log(Vector3.left);
        //Debug.Log(Vector3.back);
        //Debug.Log(Vector3.forward);

    }
}
