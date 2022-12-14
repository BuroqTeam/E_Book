using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControl_1 : MonoBehaviour
{
    public Pattern_1 Pattern1;
    public GameObject NextButton;
    public bool Answer;
    public bool Select;
    private void Start()
    {
        if (transform.GetChild(0).GetComponent<TMP_Text>().text.Contains('*'))
        {
            Answer = true;
            transform.GetChild(0).GetComponent<TMP_Text>().text = transform.GetChild(0).GetComponent<TMP_Text>().text.Replace("[*]", "");
        }
    }

    public void OnClick()
    {
        if ((NextButton.GetComponent<ButtonControl_1>().Select && !Select) || (!NextButton.GetComponent<ButtonControl_1>().Select && !Select))
        {
            transform.GetComponent<Image>().color = new Color32(0, 148, 255, 255);
            transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(255, 255, 255, 255);
            Select = true;
            if (NextButton.GetComponent<ButtonControl_1>().Select)
            {
                NextButton.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                NextButton.transform.GetChild(0).GetComponent<TMP_Text>().color = new Color32(50, 50, 50, 255);
                NextButton.GetComponent<ButtonControl_1>().Select = false;
            }
            Pattern1.NextButton.gameObject.SetActive(true);
        }
        //Pattern1.Check();
    }
}
