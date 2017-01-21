using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour {
    private ParticleSystem headExplosion;
    private GameObject head;
    private Rigidbody2D body;

    private Rigidbody2D[] rigidBodies;

    private Animator animator;

    private float timer = 0f;

    public bool headExploded = false;
    public bool dead = false;

	// Use this for initialization
	void Start () {
        headExplosion = transform.Find("Body/HeadExplosion").GetComponent<ParticleSystem>();
        head = transform.Find("Head").gameObject;
        body = transform.Find("Body").GetComponent<Rigidbody2D>();

        rigidBodies = transform.GetComponentsInChildren<Rigidbody2D>();

        animator = transform.GetComponent<Animator>();

        StartZombieWalkAnimation();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > 4f)
        {
            ExplodeHead();
        }
	}

    public void StartWalkAnimation()
    {
        for (int i=0;i<rigidBodies.Length;i++)
        {
            rigidBodies[i].isKinematic = true;

            animator.Play("Walking");
        }
    }

    public void StartZombieWalkAnimation()
    {
        for (int i = 0; i < rigidBodies.Length; i++)
        {
            head.SetActive(true);
            rigidBodies[i].isKinematic = true;

            animator.Play("Zombie_Walking");
        }
    }

    public void StartIdleAnimation()
    {
        for (int i = 0; i < rigidBodies.Length; i++)
        {
            rigidBodies[i].isKinematic = true;

            animator.Play("Idle");
        }
    }

    public void ExplodeHead()
    {
        if (!headExploded)
        {
            for (int i = 0; i < rigidBodies.Length; i++)
            {
                rigidBodies[i].isKinematic = false;
            }

            animator.Stop();

            body.AddRelativeForce(new Vector3(-5f, 0f, 0f), ForceMode2D.Impulse);
            head.SetActive(false);
            headExplosion.Play();
            headExploded = true;
        }
    }

    public void PlayerDead()
    {
        if (!dead)
        {
            for (int i = 0; i < rigidBodies.Length; i++)
            {
                rigidBodies[i].isKinematic = false;
            }

            animator.Stop();

            body.AddRelativeForce(new Vector3(-5f, 0f, 0f), ForceMode2D.Impulse);
            headExplosion.Play();
            dead = true;
        }
    }
}
