using System;
using System.Collections;
using UnityEngine;

/*
Joystick Button Map (Xbox)
A - Button 0 - Confirm
B - Button 1 - Cancel
X - Button 2 - Auxiliary
Y - Button 3 - Menu
RB - Button 5 - Trigger
*/

public class InputHandler : MonoBehaviour
{
	Action OnEveryFrame;
	public static bool onCardboard { get; private set; }

	#region Directional

	//TODO: rewrite axes' names
	readonly string moveHorizontal = "Move Horizontal";
	readonly string moveVertical = "Move Vertical";

	readonly string rotationHorizontal = "Rotation Horizontal";
	readonly string rotationVertical = "Rotation Vertical";

	public static Vector2 moveDirectional { get; private set; }
	public static Vector2 rotationDirectional { get; private set; }

	void MoveDirectionalInput()
	{
		moveDirectional = Vector2.right * Input.GetAxis(moveHorizontal) 
			+ Vector2.up * Input.GetAxis(moveVertical);
	}

	void RotationDirectionalInput()
	{
		rotationDirectional = Vector2.right * Input.GetAxis(rotationHorizontal) 
			+ Vector2.up * Input.GetAxis(rotationVertical);
	}

	#endregion

	#region Buttons

	//TODO: definir botões do joystick
	readonly string confirmButton = "Confirm"; //Mouse 0, Enter
	readonly string cancelButton = "Cancel"; //Space, Backspace
	readonly string auxiliaryButton = "Auxiliary"; //E
	readonly string menuButton = "Menu"; //Esc
	readonly string triggerButton = "Trigger"; //Left Shift

	public static bool confirm { get; private set; }
	public static bool holdConfirm { get; private set; }
	public static bool cancel { get; private set; }
	public static bool holdCancel { get; private set; }
	public static bool auxiliary { get; private set; }
	public static bool holdAuxiliary { get; private set; }
	public static bool menu { get; private set; }
	public static bool holdMenu { get; private set; }
	public static bool trigger { get; private set; }
	public static bool holdTrigger { get; private set; }

	void ButtonInput() 
	{
		confirm = Input.GetButtonDown(confirmButton);
		holdConfirm = Input.GetButton(confirmButton);

		cancel = Input.GetButtonDown(cancelButton);
		holdCancel = Input.GetButton(cancelButton);

		auxiliary = Input.GetButtonDown(auxiliaryButton);
		holdAuxiliary = Input.GetButton(auxiliaryButton);

		menu = Input.GetButtonDown(menuButton);
		holdMenu = Input.GetButton(menuButton);

		trigger = Input.GetButtonDown(triggerButton);
		holdTrigger = Input.GetButton(triggerButton);
	}

	#endregion

	private void Awake()
	{
		onCardboard = Application.platform == RuntimePlatform.Android;

		if(!onCardboard) { OnEveryFrame += RotationDirectionalInput; }
		OnEveryFrame += MoveDirectionalInput;
		OnEveryFrame += ButtonInput;
	}

	private void OnDestroy()
	{
		OnEveryFrame = null;
	}

	void Update()
	{
		OnEveryFrame();
	}
}