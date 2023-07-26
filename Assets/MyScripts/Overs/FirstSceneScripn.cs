using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirstSceneScripn : MonoBehaviour
{

	private string _conversionData;

	[SerializeField] private Button _startButton;
	[SerializeField] private TextMeshProUGUI _conversionDataText;

	void Start()
    {
		GetComponent<SaveLoadGame>().LoadGame();
		StartCoroutine(GetConversionDataToShowButton());
		if (_conversionData != null)
		{
			_conversionDataText.text = _conversionData;
			_startButton.gameObject.SetActive(true);
		}
    }

    async void GetConversionData()
	{
		// ConversionData from AppsFlyer 
		_conversionData = "***";
	}

	IEnumerator GetConversionDataToShowButton()
	{
		GetConversionData();
		while (_conversionData == null)
		{
			yield return null;
		}
	}

}
