using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using I2.Loc;

public class LanguageManager : MonoBehaviour
{
	void OnEnable()
	{
		//Debug.Log(LocalizationManager.CurrentLanguage);
		var dropdown = GetComponent<TMP_Dropdown>();
		if (dropdown == null)
			return;

		//var currentLanguage = LocalizationManager.CurrentLanguage;
		//if (LocalizationManager.Sources.Count == 0) LocalizationManager.UpdateSources();
  //      var languages = LocalizationManager.GetAllLanguages();

        //Fill the dropdown elements
		
        //dropdown.ClearOptions();
        //dropdown.AddOptions(languages);

        //dropdown.value = languages.IndexOf(currentLanguage);
        dropdown.onValueChanged.RemoveListener(OnValueChanged);
		dropdown.onValueChanged.AddListener(OnValueChanged);
	}

	void OnValueChanged(int index)
	{
		var dropdown = GetComponent<TMP_Dropdown>();
		if (index < 0)
		{
			index = 0;
			dropdown.value = index;
		}

		//LocalizationManager.CurrentLanguage = dropdown.options[index].text;
		//Debug.Log(LocalizationManager.CurrentLanguage);
	}





}
