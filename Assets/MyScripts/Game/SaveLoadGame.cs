using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadGame : MonoBehaviour
{
	private void Awake()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
			return;
		GlobalEvents.SaveGame += SaveGame;
	}

	private void SaveGame()
	{
		var iso = new PlayerData();

		iso.MaxCoins = GlobalGameSettings.MaxCoins;
		iso.MasterVolume = GlobalGameSettings.MasterVolume;
		iso.Difficulty = GlobalGameSettings.Difficulty;

		string json = JsonUtility.ToJson(iso, true);

		File.WriteAllText(Application.dataPath + "save.json", json);
	}

	public void LoadGame()
	{
		PlayerData playerData;
		try
		{
			string json = File.ReadAllText(Application.dataPath + "save.json");
			playerData = JsonUtility.FromJson<PlayerData>(json);

			if (playerData != null)
			{
				GlobalGameSettings.Difficulty = playerData.Difficulty;
				GlobalGameSettings.MaxCoins = playerData.MaxCoins;
				GlobalGameSettings.MasterVolume = playerData.MasterVolume;

				Debug.Log(GlobalGameSettings.Difficulty + " " + GlobalGameSettings.MaxCoins + " " + GlobalGameSettings.MasterVolume);
			}

		}
		catch (System.Exception e)
		{
			Debug.Log("Save unknow " + e);
			throw;
		}
	}
}
