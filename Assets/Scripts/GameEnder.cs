using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour {
	public string[] zombieTags;
    private bool gameEnded = false;

	void OnCollisionEnter2D (Collision2D other_ ){
		if (other_.gameObject.tag == "Zombie" && !gameEnded) {
			// end the game
			Debug.Log("Game over!");

            gameEnded = true;

            gameObject.GetComponent<RagdollController>().PlayerDead();
		}
	}
}
