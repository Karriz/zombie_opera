using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMover : MonoBehaviour {
	public float speed = 1.0f;
	public Vector3 direction;
    private RagdollController ragdoll;
    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		this.direction.Normalize ();
        ragdoll = gameObject.GetComponent<RagdollController>();

        body = gameObject.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        /*if (!ragdoll.isWalking)
        {
            ragdoll.StartZombieWalkAnimation();
        }*/

        if (!ragdoll.headExploded)
        {
            Vector2 velocity = body.velocity;
            velocity.x = direction.x * speed;
            body.velocity = velocity;
        }
	}
}
