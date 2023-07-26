using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
	[SerializeField] private GameObject _menu;
	[SerializeField] private TextMeshProUGUI _coinsText;
	[SerializeField] private TextMeshProUGUI _difficultyText;
	[SerializeField] private Slider _volume;

	private void Awake()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
			return;

		GlobalEvents.EndGame += OpenInterface;
		GlobalEvents.CoinTaked += CoinTaked;
		_volume.value = GlobalGameSettings.MasterVolume;
	}

	public void ButtonSaveGame()
	{
		GlobalEvents.SaveGame();
	}
	public void ButtonStartGame()
	{
		GlobalEvents.StartNewGame();
		ClouseInterface();
	}
	public void ButtonUpdateSettings()
	{
		GlobalEvents.SaveGame();
	}
	public void ButtonUpdateVolume()
	{
		GlobalGameSettings.MasterVolume = _volume.value;
	}

	private void ClouseInterface()
	{
		_menu.gameObject.SetActive(false);
	}
	private void OpenInterface()
	{
		_menu.gameObject.SetActive(true);
	}
	private void CoinTaked()
	{
		if (GlobalGameSettings.CurrentCoins != 0)
			_coinsText.text = "" + GlobalGameSettings.CurrentCoins;
	}

	public void ButtonDifficulty(int DifficultyNumber)
	{
		if (DifficultyNumber <= 1)
		{
			GlobalGameSettings.Difficulty = Difficulty.Easy;
			_difficultyText.text = "Easy";
		}
		else if (DifficultyNumber == 2)
		{
			GlobalGameSettings.Difficulty = Difficulty.Normal;
			_difficultyText.text = "Normal";
		}
		else
		{
			GlobalGameSettings.Difficulty = Difficulty.Hard;
			_difficultyText.text = "Hard";
		}
		GlobalEvents.SaveGame();
	}

	public void ButtonGoToScene(int SceneIndexToLoad)
	{
		StartCoroutine(StartScene(SceneIndexToLoad));
	}

	IEnumerator StartScene(int SceneIndexToLoad)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndexToLoad);

		while (!operation.isDone)
		{
			yield return null;
		}
	}
}
