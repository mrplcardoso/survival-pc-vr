using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
  PlayerUnit playerUnit;
  PlayerAttributes playerAttributes;
  CharacterController controller;

  Vector3 xVelocity, yVelocity, zVelocity;
  Vector3 velocity { get { return xVelocity + yVelocity + zVelocity; } }

  void Awake()
  {
    playerUnit = GetComponent<PlayerUnit>();
    playerAttributes = GetComponent<PlayerAttributes>();
    controller = GetComponent<CharacterController>();

    playerUnit.AddFrameAction(MoveAction);
  }

	private void Start()
	{
		walkAttribute = playerAttributes[AttributeType.Walk];
    sprintAttribute = playerAttributes[AttributeType.Sprint];
    jumpAttribute = playerAttributes[AttributeType.Jump];
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

  AttributeData walkAttribute, sprintAttribute;
  float walk => walkAttribute.value;
  float sprint => sprintAttribute.value;
	float cacheSpeed;
	bool sprinting => InputHandler.holdTrigger;

	void MoveInput()
  {
		Vector2 direction = Vector2.ClampMagnitude(InputHandler.moveDirectional, 1f);
    if (direction.sqrMagnitude <= 0.0001f) { cacheSpeed = 0; }
    else
    {
      if (sprinting) { cacheSpeed = sprint; }
      else { cacheSpeed = walk; }
    }

    xVelocity = direction.x * cacheSpeed * transform.right;
    zVelocity = direction.y * cacheSpeed * transform.forward;
  }

  #endregion

  #region Jump Input

  AttributeData jumpAttribute;
  float jump => jumpAttribute.value;
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