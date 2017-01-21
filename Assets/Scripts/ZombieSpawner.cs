using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {
	public GameObject zombiePrefab;
	public int bufferSize = 16;
	public float spawnFrequency = 2.0f;

	private float timeCounter = 0.0f;
	private ArrayList activeZombies = new ArrayList();
	private Stack inactiveZombies = new Stack();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < this.bufferSize; i++) {
			GameObject zombie = GameObject.Instantiate (this.zombiePrefab);
			zombie.SetActive (false);
			this.inactiveZombies.Push (zombie);
		}
	}
	
	// Update is called once per frame
	void Update () {
		this.timeCounter += Time.deltaTime;
		if (this.spawnFrequency <= this.timeCounter) {
			this.timeCounter = 0.0f;
			GameObject zombie;
			if (this.inactiveZombies.Count >= 1) {
				zombie = this.inactiveZombies.Pop () as GameObject;
			} else {
				zombie = GameObject.Instantiate (this.zombiePrefab);
			}
			zombie.transform.position = this.gameObject.transform.position;
			zombie.SetActive (true);
			this.activeZombies.Add (zombie);
		}
	}

	public void DeactivateZombie( GameObject zombie_ ) {
		if (this.activeZombies.Contains (zombie_)) {
			this.activeZombies.Remove (zombie_);
		} else {
			Debug.LogWarning ("The zombie you're trying to deactivate was not in the active zombies stack :O");
		}
		zombie_.SetActive (false);
		this.inactiveZombies.Push (zombie_);
	}
}
