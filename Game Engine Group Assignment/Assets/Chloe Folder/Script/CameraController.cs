using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// speed of camera movement
	public float panSpeed = 5.0f;
	// limit the panning
	public Vector2 viewLimit;

	// for camera zoom
	public float zoomSpeed = 5.0f;
	public float scrollSpeed = 50.0f;
	public float smooth = 0.25f;
	public float minZoom = 15.0f;
	public float maxZoom = 80.0f;
	private Vector3 velocity = Vector3.zero;

	void Update()
	{
		// get camera position
		Vector3 camPos = transform.position;
		float panX = camPos.x;
		float panZ = camPos.z;
		float zoomY = camPos.y;

		// move camera based on key inputs
		if (Input.GetKey(KeyCode.W))
		{
			panZ += AddSpeed(panSpeed);
		}
		if (Input.GetKey(KeyCode.S))
		{
			panZ -= AddSpeed(panSpeed);
		}
		if (Input.GetKey(KeyCode.D))
		{
			panX += AddSpeed(panSpeed);
		}
		if (Input.GetKey(KeyCode.A))
		{
			panX -= AddSpeed(panSpeed);
		}

		// zoom camera based on scrollWheel
		if (Input.mouseScrollDelta.y > 0)
		{
			zoomY -= AddSpeed(scrollSpeed);
		}
		if (Input.mouseScrollDelta.y < 0)
		{
			zoomY += AddSpeed(scrollSpeed);
		}
		// zoom camera based on inputs
		if (Input.GetKey(KeyCode.Q))
		{
			zoomY += AddSpeed(zoomSpeed);
		}
		if (Input.GetKey(KeyCode.E))
		{
			zoomY -= AddSpeed(zoomSpeed);
		}

		// limit camera pan
		camPos.z = Mathf.Clamp(panZ, -panLimit.y, panLimit.y);
		camPos.x = Mathf.Clamp(panX, -panLimit.x, panLimit.x);

		// limit camera zoom
		camPos.y = Mathf.Clamp(zoomY, minZoom, maxZoom);

		// smooth camera
		transform.position = Vector3.SmoothDamp(transform.position, camPos,
			ref velocity, smooth);
	}

	float AddSpeed(float speed)
	{
		return speed * Time.deltaTime;
	}
}
