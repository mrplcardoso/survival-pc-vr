using System;
using UnityEngine;
using Utility.SceneCamera;

public class PlayerCamera : MonoBehaviour
{
	PlayerUnit playerUnit;

	SceneCamera sceneCamera { get { return SceneCamera.instance; } }
	[SerializeField] Transform head;

	Vector2 rotation;
	[SerializeField] float mouseSensitivity = 10;
	const float minAngle = -50, maxAngle = 50;

	private void Awake()
	{
		if(head == null) { PrintConsole.Error("Player Head not defined"); }

		//TODO: mover para FSM
		Cursor.lockState = CursorLockMode.Locked;
		playerUnit = GetComponent<PlayerUnit>();
	}

	private void Start()
	{
		if(InputHandler.onCardboard) { playerUnit.AddFrameAction(FromVR); }
		else { playerUnit.AddFrameAction(FromMouse); }

		playerUnit.AddPostAction(CameraOnHead);
	}

	void OnDestroy()
	{
		playerUnit.RemoveFrameAction(FromVR);
		playerUnit.RemoveFrameAction(FromMouse);
		playerUnit.RemovePostAction(CameraOnHead);
	}

	void FromMouse()
	{
		rotation += InputHandler.rotationDirectional * mouseSensitivity;
		rotation.y = Mathf.Clamp(rotation.y, minAngle, maxAngle);

		sceneCamera.transform.eulerAngles = new Vector3(-rotation.y, rotation.x, 0);
		transform.eulerAngles = new Vector3(0, rotation.x, 0);
	}

	void FromVR()
	{
		Vector3 euler = transform.eulerAngles;
		euler.y = sceneCamera.transform.eulerAngles.y;
		transform.eulerAngles = euler;
	}

	void CameraOnHead()
	{
		sceneCamera.transform.position = head.position;
	}
}
