using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SizeFitter : MonoBehaviour
{
    [ContextMenu("Resize")]
    public void Resize()
    {
        this.Invoke(() =>
        {
            float a = 0;
            foreach (Transform VARIABLE in transform)

            {
                if (VARIABLE.gameObject.activeSelf)
                {
                    a += VARIABLE.GetComponent<RectTransform>().sizeDelta.y;
                    a += 25;
                }
            }

            a += 50;

            GetComponent<RectTransform>().DOSizeDelta(new Vector2(280, a), 1.5f).SetEase(Ease.OutElastic);

        }, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
