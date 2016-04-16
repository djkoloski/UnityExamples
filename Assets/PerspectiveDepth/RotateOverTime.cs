using UnityEngine;
using System.Collections.Generic;

public class RotateOverTime : MonoBehaviour
{
	public float rotationSpeed;

	private Vector3 rotationAxis_;

	public void Awake()
	{
		rotationAxis_ = Random.onUnitSphere;
	}
	public void Update()
	{
		transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationAxis_);
	}
}
