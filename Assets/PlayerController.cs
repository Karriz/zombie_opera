using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D body;

    private RagdollController ragdoll;
     
    void Start()
    {
        ragdoll = transform.GetComponent<RagdollController>();
        body = transform.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.D) && !ragdoll.dead) {
            transform.localScale.Set(-1, 1, 1);
            gameObject.transform.localScale = new Vector3(-1,1,1);
            Vector2 velocity = body.velocity;
            velocity.x = 5f;
            body.velocity = velocity;

            ragdoll.StartWalkAnimation();

        }

        else if (Input.GetKey(KeyCode.A) && !ragdoll.dead)
        {
            transform.localScale.Set(1,1,1);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            Vector2 velocity = body.velocity;
            velocity.x = -5f;
            body.velocity = velocity;

            ragdoll.StartWalkAnimation();

        }

        else if (!ragdoll.dead)
        {
            Vector2 velocity = body.velocity;
            velocity.x = 0f;
            body.velocity = velocity;

            ragdoll.StartIdleAnimation();
        }

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            transform.localScale.Set(1, 1, 1);
            Vector2 velocity = body.velocity;
            velocity.y = 10f;
            body.velocity = velocity;

        }*/
    }
}
