using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGame : MonoBehaviour
{

    [SerializeField] private bool _gameIsPlaying;
	[SerializeField] private GameObject[] _tubes;

	[Range(1,10)]
	[SerializeField] private float _speedPlatforms = 1;

	private float _totalDistanceFlyed;

	private void Awake()
	{
		GlobalEvents.EndGame += EndGame;
		GlobalEvents.StartNewGame += StartGame;
	}

	void Update()
    {
        if (!_gameIsPlaying) return;

		_totalDistanceFlyed += Time.deltaTime * _speedPlatforms;
		if (_totalDistanceFlyed > 6)
		{
			GlobalGameSettings.CurrentCoins += 1;
			_totalDistanceFlyed = 0;
			GlobalEvents.CoinTaked();
		} 
		for (int i = 0; i < _tubes.Length; i++)
		{
			_tubes[i].transform.position -= transform.right * Time.deltaTime * _speedPlatforms;

			if (_tubes[i].transform.position.x < -15)
			{
				_tubes[i].transform.position = new Vector3(15, Random.RandomRange(-3f,3f), 0);
			}
		}

		GetComponent<PlayerControl>().Play();
    }

	void EndGame()
	{
		_gameIsPlaying = false;

		if (GlobalGameSettings.CurrentCoins > GlobalGameSettings.MaxCoins)
		{
			GlobalGameSettings.MaxCoins = GlobalGameSettings.CurrentCoins;
			GlobalEvents.SaveGame();
		}

	}
	void StartGame()
	{
		if (GlobalGameSettings.Difficulty == Difficulty.Easy)
			_speedPlatforms = 1; 
		else if (GlobalGameSettings.Difficulty == Difficulty.Normal)
			_speedPlatforms = 3;
		else
			_speedPlatforms = 6;

		_gameIsPlaying = true;
		GetComponent<PlayerControl>().ResetPosition();
		GlobalGameSettings.CurrentCoins = 0;
		GlobalEvents.CoinTaked();
		_totalDistanceFlyed = 0;
		for (int i = 0; i < _tubes.Length; i++)
		{
			_tubes[i].transform.position = new Vector3(0 + i * 6, Random.RandomRange(-3f, 3f), 0);
		}
	}
}
