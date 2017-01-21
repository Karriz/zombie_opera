using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour {
	public string[] zombieTags;

	void OnTriggerEnter2D (Collider2D other_ ){
		foreach (string zombieTag in this.zombieTags) {
			if (other_.CompareTag (zombieTag)) {
				// end the game
				Debug.Log("Game over!");
			}
		}
	}
}
