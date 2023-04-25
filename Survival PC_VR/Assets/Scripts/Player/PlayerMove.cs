using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
  PlayerUnit playerUnit;
  CharacterController controller;

  Vector3 xVelocity, yVelocity, zVelocity;
  Vector3 velocity { get { return xVelocity + yVelocity + zVelocity; } }

  void Awake()
  {
    playerUnit = GetComponent<PlayerUnit>();
    controller = GetComponent<CharacterController>();

    playerUnit.AddFrameAction(MoveAction);
  }

	private void OnDestroy()
	{
		playerUnit.RemoveFrameAction(MoveAction);
	}

	void MoveAction()
  {
    MoveInput();
    JumpInput();
    controller.Move(velocity * Time.deltaTime);
  }

	#region Move Input

	[SerializeField] float walk, sprint;
	float cacheSpeed;

	void MoveInput()
  {
    bool sprinting = InputHandler.holdTrigger;
    if (sprinting) { cacheSpeed = sprint; }
    else { cacheSpeed = walk; }

    Vector2 direction = Vector2.ClampMagnitude(InputHandler.moveDirectional, 1f);
    xVelocity = direction.x * cacheSpeed * transform.right;
    zVelocity = direction.y * cacheSpeed * transform.forward;
  }

	#endregion

	#region Jump Input

	[SerializeField] float jump;
	const float gravity = 20f;

	void JumpInput()
  {
    yVelocity += gravity * Time.deltaTime * Vector3.down;
    if (controller.isGrounded) { yVelocity = Vector3.down; }

    if (controller.isGrounded && InputHandler.cancel)
    { yVelocity = Vector3.up * jump; }
  }

  #endregion
}