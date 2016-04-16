using UnityEngine;
using System.Collections;

public class PerspectiveDepthCamera : MonoBehaviour
{
	public float viewingPlaneWidth;

	private Camera camera_;

	public void Awake()
	{
		camera_ = GetComponent<Camera>();
	}
	public void Update()
	{
		float nearPlane = viewingPlaneWidth / 2.0f / Mathf.Tan(camera_.fieldOfView / 2.0f * Mathf.Deg2Rad);
		transform.localPosition = new Vector3(0.0f, 0.0f, -nearPlane);
		camera_.nearClipPlane = nearPlane;
	}
}
