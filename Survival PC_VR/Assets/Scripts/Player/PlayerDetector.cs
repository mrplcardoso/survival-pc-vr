using System;
using Unity.VisualScripting;
using UnityEngine;
using Utility.SceneCamera;

public class PlayerDetector : MonoBehaviour
{
	PlayerUnit playerUnit;

	CameraRaycaster raycaster { get { return SceneCamera.instance.raycaster; } }
	[SerializeField] LayerMask mask;
	[SerializeField] float range;

	Action<IDetectable> OnDetected;

	void Awake()
	{
		playerUnit = GetComponent<PlayerUnit>();
		playerUnit.AddFrameAction(DetectAction);
	}

	void OnDestroy()
	{
		playerUnit.RemoveFrameAction(DetectAction);
	}

	IDetectable Detect()
	{
		RaycastHit hit = raycaster.Raycast(range, mask);
		if(hit.collider == null) { return null; }

		return hit.collider.GetComponent<IDetectable>();
	}

	void DetectAction()
	{
		IDetectable detected = Detect();
		if (OnDetected != null) { OnDetected(detected);	}
	}

	public void AddObserver(Action<IDetectable> onDetect)
	{
		OnDetected -= onDetect;
		OnDetected += onDetect;
	}

	public void RemoveObserver(Action<IDetectable> onDetect) 
	{
		OnDetected -= onDetect;
	}
}
