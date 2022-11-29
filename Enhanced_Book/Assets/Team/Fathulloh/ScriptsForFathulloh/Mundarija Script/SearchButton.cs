using UnityEngine;
using UnityEngine.UI;

namespace FathullohExample
{
    public class SearchButton : MonoBehaviour
    {
        public GameObject TextSearch;
        public Sprite InitialSprite, AfterClickingSprite;
        public bool _IsClicked = false;


        void Start()
        {

        }


        public void ClickSearch()
        {
            if (!_IsClicked)
            {
                _IsClicked = true;
                TextSearch.SetActive(false);
                gameObject.GetComponent<Image>().sprite = AfterClickingSprite;                
            }
            else if (_IsClicked)
            {
                _IsClicked = false;
                TextSearch.SetActive(true);
                gameObject.GetComponent<Image>().sprite = InitialSprite;
            }
        }




    }
}
