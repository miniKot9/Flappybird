using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColliderToStopGame : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision != null)
			GlobalEvents.EndGame();
	}
}
