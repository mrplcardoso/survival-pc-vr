using System.Collections;
using UnityEngine;

public interface IUpdatable
{
	public bool isActive { get; }
	public void FrameUpdate();
	public void PhysicsUpdate();
	public void PostUpdate();
}