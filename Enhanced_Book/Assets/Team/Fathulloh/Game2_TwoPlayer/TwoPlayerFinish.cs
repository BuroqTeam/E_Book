using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game2_TwoPlayer
{
    public class TwoPlayerFinish : MonoBehaviour
    {
        public Sprite GoldBadge;
        public Sprite SilverBadge;
        public Sprite BronzeBadge;

        public GameManage GameManager1;
        public GameManage GameManager2;

        public GameObject ParentBadges;
        public GameObject Badge1;
        public GameObject Badge2;


        public float durration;
        public float LongTime;

        void Start()
        {
            //GetBadgeObjects();
        }

        
        //void GetBadgeObjects()
        //{
        //    ParentBadges = transform.GetChild(0).transform.GetChild(1).gameObject;
        //    Badge1 = ParentBadges.transform.GetChild(0).gameObject;
        //    Badge2 = ParentBadges.transform.GetChild(1).gameObject;
        //}


        public void ChooseBadges()
        {
            if (GameManager1.CurrentTask >= GameManager1.TotalTask) 
            {
                Badge1.GetComponent<Image>().sprite = GoldBadge;
                Badge2.GetComponent<Image>().sprite = SilverBadge;
            }
            else if (GameManager2.CurrentTask >= GameManager2.TotalTask)
            {
                Badge1.GetComponent<Image>().sprite = SilverBadge;
                Badge2.GetComponent<Image>().sprite = GoldBadge;
            }
            else
            {
                ParentBadges.SetActive(false);
                gameObject.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
            }
        }


        public void SwitchPanel()
        {
            gameObject.transform.GetChild(0).transform.localScale = new Vector3(0, 0, 0);
            gameObject.SetActive(true);
            StartCoroutine(SwitchingPanel());

        }


        IEnumerator SwitchingPanel()
        {
            yield return new WaitForSeconds(0.05f);
            if (LongTime == 0)
            {
                yield return new WaitForSeconds((float)durration / 4);
                gameObject.transform.GetChild(0).transform.DOScale(1, 3 * (float)durration / 4);
            }
            else if (LongTime != 0)
            {
                yield return new WaitForSeconds((float)durration / 2);
                gameObject.transform.GetChild(0).transform.DOScale(1, 3 * (float)durration / 3);
            }
        }


    }
}
