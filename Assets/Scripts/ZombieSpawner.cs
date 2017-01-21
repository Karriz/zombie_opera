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
            ZombieDestroyer zombieDestroyer = zombie.GetComponent<ZombieDestroyer>();

            string[] Levels = { "Low", "Mid", "High"};

            zombieDestroyer.currentTag = Levels[(int)Random.Range(0f, Levels.Length-0.1f)];
            
            zombieDestroyer.zombieSpawner = this;

            if (zombieDestroyer.currentTag == "Low") {
                zombie.transform.Find("Head").GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (zombieDestroyer.currentTag == "Mid")
            {
                zombie.transform.Find("Head").GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (zombieDestroyer.currentTag == "High")
            {
                zombie.transform.Find("Head").GetComponent<SpriteRenderer>().color = Color.green;
            }

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

                ZombieDestroyer zombieDestroyer = zombie.GetComponent<ZombieDestroyer>();

                string[] Levels = { "Low", "Mid", "High" };

                zombieDestroyer.currentTag = Levels[(int)Random.Range(0f, Levels.Length - 0.1f)];

                zombieDestroyer.zombieSpawner = this;

                if (zombieDestroyer.currentTag == "Low")
                {
                    zombie.transform.Find("Head").GetComponent<SpriteRenderer>().color = Color.red;
                }
                else if (zombieDestroyer.currentTag == "Mid")
                {
                    zombie.transform.Find("Head").GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                else if (zombieDestroyer.currentTag == "High")
                {
                    zombie.transform.Find("Head").GetComponent<SpriteRenderer>().color = Color.green;
                }

            }
			zombie.transform.position = this.gameObject.transform.position;
			zombie.SetActive (true);

            if (zombie.GetComponent<Rigidbody2D>() == null)
            {
                Rigidbody2D body = zombie.AddComponent<Rigidbody2D>();
                body.freezeRotation = true;

            }

            zombie.GetComponent<RagdollController>().StartZombieWalkAnimation();
            zombie.GetComponent<Collider2D>().isTrigger = false;
            this.activeZombies.Add (zombie);
		}
	}

	public void DeactivateZombie( GameObject zombie_ ) {
		if (this.activeZombies.Contains (zombie_)) {
			this.activeZombies.Remove (zombie_);
		} else {
			Debug.LogWarning ("The zombie you're trying to deactivate was not in the active zombies stack :O");
		}


        //zombie_.SetActive (false);
        zombie_.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        Destroy(zombie_.GetComponent<Rigidbody2D>());
        Destroy(zombie_.GetComponent<CapsuleCollider2D>());

        zombie_.GetComponent<RagdollController>().ExplodeHead();

		//this.inactiveZombies.Push (zombie_);
	}
}
