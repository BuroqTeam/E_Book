using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelTestEditor : MonoBehaviour
{
    Texture2D t2D;

    private void Start()
    {
        var _rawImage = GetComponent<RawImage>();
        t2D = _rawImage.texture as Texture2D;
        var _pixelData = t2D.GetPixels();
        print("Total pixels " + _pixelData.Length);
        var _colorIndex = new List<Color>();
        var _total = _pixelData.Length;
        for (var i = 0; i < _total; i++)
        {
            var _color = _pixelData[i];
            if (_colorIndex.IndexOf (_color) == -1)
            {
                _colorIndex.Add(_color);
                if (ColorUtility.ToHtmlStringRGB(_color) == "FFFFFF")
                {
                    Debug.Log("Pikseli: " + i);
                }
            }
        }
        print("Indexed colors " + _colorIndex.Count);

        foreach (var color in _colorIndex)
        {
            if (ColorUtility.ToHtmlStringRGB(color) == "FFFFFF")
            {
                Debug.Log("Topdi");
            }
            //print("#" + ColorUtility.ToHtmlStringRGB(color));
            
        }
    }
}

