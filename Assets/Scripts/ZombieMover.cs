using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMover : MonoBehaviour {
	public float speed = 1.0f;
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		this.direction.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (this.direction * this.speed * Time.deltaTime);
	}
}
