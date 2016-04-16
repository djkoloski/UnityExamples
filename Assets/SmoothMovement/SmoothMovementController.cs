using UnityEngine;

public class SmoothMovementController : MonoBehaviour
{
	public bool chaseTarget;
	public Transform target;
	public float maxVelocity;
	public float acceleration;
	public float maxAcceleration;
	public float timeToReach;

	private Rigidbody2D rigidbody2d_;

	public void AccelerateClamped(Vector2 targetVelocity)
	{
		// dv is the difference between our desired velocity and our current velocity
		Vector2 dv = targetVelocity - rigidbody2d_.velocity;
		// Set the magnitude of dv to the min of the max acceleration and its magnitude times acceleration
		dv = dv.normalized * Mathf.Min(dv.magnitude * acceleration, maxAcceleration);
		// dv is now the acceleration we want to add to our rigidbody
		// Rigidbody2D doesn't have an acceleration ForceMode2D, so we use F = m * a to do the same thing
		rigidbody2d_.AddForce(dv * rigidbody2d_.mass, ForceMode2D.Force);
	}
	public void AccelerateClampedToward(Vector2 target)
	{
		// Our target velocity is the vector from our position to the target
		Vector2 targetVelocity = target - rigidbody2d_.position;
		// We want our object to slow down on approach, otherwise it will overshoot
		// If we don't do this step, our object will always begin to slow down at maxVelocity distance away
		targetVelocity = targetVelocity.normalized * Mathf.Min(targetVelocity.magnitude / timeToReach, maxVelocity);
		// Now we can use our AccelerateClamped function to help
		AccelerateClamped(targetVelocity);
	}
	public void ClampVelocity()
	{
		// Cap the velocity at maxVelocity
		rigidbody2d_.velocity = rigidbody2d_.velocity.normalized * Mathf.Min(rigidbody2d_.velocity.magnitude, maxVelocity);
	}

	public void Awake()
	{
		rigidbody2d_ = GetComponent<Rigidbody2D>();
	}
	public void Update()
	{
		if (chaseTarget)
			AccelerateClampedToward(target.position);
		else
			AccelerateClamped(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * maxVelocity);
	}
	public void FixedUpdate()
	{
		ClampVelocity();
	}
}