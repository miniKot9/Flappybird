using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;

    private Vector2 _startPosition;

	private void Awake()
	{
		GlobalEvents.EndGame += StopGame;
	}

	public void Play()
    {
        if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
		{
            _playerRigidbody.AddForce(new Vector2(0,300));
        }
    }

    public void ResetPosition()
	{
		_playerRigidbody.gameObject.transform.position = _startPosition;
		_playerRigidbody.bodyType = RigidbodyType2D.Dynamic;
	}

	private void Start()
	{
		if (_playerRigidbody != null)
			_startPosition = _playerRigidbody.gameObject.transform.position;
	}

	private void StopGame ()
	{
		_playerRigidbody.bodyType = RigidbodyType2D.Static;
	}
}
