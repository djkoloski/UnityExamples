using UnityEngine;
using System.Collections.Generic;

public class FastDiagonalsMovementController : MonoBehaviour
{
	public bool logVelocityMagnitude;
	public bool normalizeMovement;
	public float movementSpeed;

	private Rigidbody2D rigidbody2d_;

	public void Awake()
	{
		rigidbody2d_ = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		if (normalizeMovement)
			rigidbody2d_.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * movementSpeed;
		else
			rigidbody2d_.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * movementSpeed;

		if (logVelocityMagnitude)
			Debug.Log(rigidbody2d_.velocity.magnitude);
	}
}