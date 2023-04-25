using System;
using System.Collections;
using UnityEngine;

public class PlayerUnit : MonoBehaviour, IUpdatable
{
	Action OnFrameAction, OnPhysicsAction, OnPostAction;
	public bool isActive => gameObject.activeInHierarchy;

	#region Add/Remove

	public void AddFrameAction(Action action)
	{
		OnFrameAction -= action;
		OnFrameAction += action;
	}

	public void RemoveFrameAction(Action action)
	{
		OnFrameAction -= action;
	}

	public void AddPhysicsAction(Action action)
	{
		OnPhysicsAction -= action;
		OnPhysicsAction += action;
	}

	public void RemovePhysicsAction(Action action)
	{
		OnPhysicsAction -= action;
	}

	public void AddPostAction(Action action)
	{
		OnPostAction -= action;
		OnPostAction += action;
	}

	public void RemovePostAction(Action action)
	{
		OnPostAction -= action;
	}

	#endregion

	#region Action

	public void FrameUpdate()
	{
		if(OnFrameAction != null)
		{  OnFrameAction(); }
	}

	public void PhysicsUpdate()
	{
		if(OnPhysicsAction != null)
		{ OnPhysicsAction(); }
	}

	public void PostUpdate()
	{
		if(OnPostAction != null)
		{ OnPostAction(); }
	}

	#endregion

	//TODO: remover
	void Update()
	{
		FrameUpdate();
	}
	private void LateUpdate()
	{
		PostUpdate();	
	}
}