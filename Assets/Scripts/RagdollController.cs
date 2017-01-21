using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour {
    private ParticleSystem headExplosion;
    private GameObject head;
    private Rigidbody2D body;

    private Rigidbody2D[] rigidBodies;
    private BoxCollider2D[] boxColliders;

    private Animator animator;

    public bool headExploded = false;
    public bool dead = false;

    public bool isWalking = false;

	// Use this for initialization
	void Awake () {
        headExplosion = transform.Find("Body/HeadExplosion").GetComponent<ParticleSystem>();
        head = transform.Find("Head").gameObject;
        body = transform.Find("Body").GetComponent<Rigidbody2D>();

        rigidBodies = transform.GetComponentsInChildren<Rigidbody2D>();

        boxColliders = transform.GetComponentsInChildren<BoxCollider2D>();

        animator = transform.GetComponent<Animator>();

        StartIdleAnimation();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void StartWalkAnimation()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        for (int i = 0; i < boxColliders.Length; i++)
        {
            if (boxColliders[i] != null)
            {
                boxColliders[i].isTrigger = true;
            }
        }
        animator.Play("Walking");

        isWalking = true;
    }

    public void StartZombieWalkAnimation()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;

        for (int i = 0; i < boxColliders.Length; i++)
        {
            if (boxColliders[i] != null)
            {
                boxColliders[i].isTrigger = true;
            }
        }

        head.SetActive(true);
        animator.Play("Zombie_Walking");

        isWalking = true;
    }

    public void StartIdleAnimation()
    {
        for (int i = 0; i < boxColliders.Length; i++)
        {
            if (boxColliders[i] != null)
            {
                boxColliders[i].isTrigger = true;
            }
        }

        animator.Play("Idle");

        isWalking = false;
    }

    public void ExplodeHead()
    {
        if (!headExploded)
        {

            animator.Stop();

            head.SetActive(false);

            Destroy(head);

            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (boxColliders[i] != null)
                {
                    boxColliders[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    boxColliders[i].isTrigger = false;
                    //boxColliders[i].gameObject.AddComponent<Rigidbody2D>();
                }
            }

            body.AddRelativeForce(new Vector3(transform.localScale.x*-50f, 0f, 0f), ForceMode2D.Impulse);


            /*transform.Find("Head").SetParent(null);
            transform.Find("Body").SetParent(null);
            transform.Find("Left_Arm").SetParent(null);
            transform.Find("Right_Arm").SetParent(null);
            transform.Find("Left_Leg").SetParent(null);
            transform.Find("Right_Leg").SetParent(null);*/

            headExplosion.Play();
            headExploded = true;

            isWalking = false;

            Destroy(gameObject, 5f);
        }
    }

    public void PlayerDead()
    {
        if (!dead)
        {

            

            animator.Stop();

            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (boxColliders[i] != null && boxColliders[i].tag != "Low" && boxColliders[i].tag != "Mid" && boxColliders[i].tag != "High")
                {
                    boxColliders[i].transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    boxColliders[i].isTrigger = false;
                    //boxColliders[i].gameObject.AddComponent<Rigidbody2D>();
                }

            }

            body.AddRelativeForce(new Vector3(transform.localScale.x * 50f, 0f, 0f), ForceMode2D.Impulse);

            headExplosion.Play();
            dead = true;
            isWalking = false;
        }
    }
}
