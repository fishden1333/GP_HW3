﻿using UnityEngine;
using System.Collections;

public class Character2D : MonoBehaviour
{
	public float maxSpeed = 10.0f;
	public float jumpForce = 800.0f;

	public bool airControl = true;

	bool facingRight;
	bool upsideDown;

	public LayerMask groundLayer;

	Transform groundCheck;
	float groundRadius;
	bool onGround;

	Animator anim;
	private float gravity;

	void Awake()
	{
		//get references
		groundCheck = transform.Find ("GroundCheck");
		anim = GetComponent<Animator> ();
		gravity = GetComponent<Rigidbody2D>().gravityScale;
	}

	// Use this for initialization
	void Start ()
	{
		facingRight = true;
		upsideDown = false;
		groundRadius = 0.1f;
		onGround = false;
	}

	void FixedUpdate ()
	{
		//detect if the character is standing on the ground
		//bool OverlapCircle(point, rad, LayerMask)
		//returns true if there's anything in "layerMask" exist inside a circle centers at "point" (Vector2) with radius="rad" (float)
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundLayer);

		//change the character animation by onGround state
		anim.SetBool("onGround", onGround);
	}

	public void Move(float movingSpeed, bool jump)
	{
		//left / right moving actived only when the character is on the ground or air control is premitted
		if (onGround || airControl)
		{
			//change the character animation by moving speed
			anim.SetFloat("Speed", Mathf.Abs(movingSpeed));

			//move the character
			//only change its velocity on x axis
			GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

			//flip the character image if player input direction is different with character's facing direction
			if (movingSpeed > 0 && !facingRight || movingSpeed < 0 && facingRight) Flip ();
		}

		//let character jump when it's on the ground and player hits jump button
		if (onGround && jump)
		{
			anim.SetBool ("onGround", false);

			//make character jump by adding force
			if (!upsideDown)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
			}
			else
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -1 * jumpForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
    if (coll.gameObject.tag == "Flip")
		{
			gravity = gravity * -1;
			GetComponent<Rigidbody2D>().gravityScale = gravity;
			upsideDown = !upsideDown;
			Vector3 characterScale = transform.localScale;
			characterScale.y *= -1;
			transform.localScale = characterScale;
		}
  }

	void Flip()
	{
		//reverse the direction
		facingRight = !facingRight;

		//flip the character by multiplying x local scale with -1
		Vector3 characterScale = transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;
	}
}
