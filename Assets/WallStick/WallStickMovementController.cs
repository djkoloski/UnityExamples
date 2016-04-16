using UnityEngine;
using System.Collections.Generic;

public class WallStickMovementController : MonoBehaviour
{
	// Whether to set the velocity or use forces
	public bool setVelocity;
	// The distance that we consider our character to be "grounded" at
	public float groundedDist;
	// How fast the character moves horizontally
	public float movementSpeed;
	// How strongly the character jumps
	public float jumpSpeed;
	// How long the character has to wait before jumping again
	public float jumpCooldown;

	// Private variables
	private Rigidbody2D rigidbody2d_;
	private float jumpTimer_;

	public void Awake()
	{
		// Grab our rigidbody and set our jump timer to 0
		rigidbody2d_ = GetComponent<Rigidbody2D>();
		jumpTimer_ = 0.0f;
	}

	public void Update()
	{
		if (setVelocity)
		{
			// If we use this, we'll cause our character to stick to walls
			rigidbody2d_.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rigidbody2d_.velocity.y);
		}
		else
		{
			// By adding forces, we don't cause our character to stick to walls
			rigidbody2d_.AddForce(Input.GetAxis("Horizontal") * Vector2.right * movementSpeed);
		}

		// If we're cooling down from jumping, don't let the player jump
		if (jumpTimer_ > 0.0f)
			jumpTimer_ -= Time.deltaTime;
		else if (Input.GetAxis("Vertical") > 0.1f && CheckIsGrounded())
		{
			// Else, jump if they pressed up and they're grounded
			rigidbody2d_.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
			jumpTimer_ = jumpCooldown;
		}
	}

	public bool CheckIsGrounded()
	{
		// Raycast down from our pivot and see if we hit anything
		return Physics2D.Raycast(transform.position + Vector3.down * 0.01f, Vector2.down, groundedDist).collider != null;
	}
}