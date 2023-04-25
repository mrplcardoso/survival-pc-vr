using UnityEngine;
using UnityEngine.SpatialTracking;

namespace Utility.SceneCamera
{
	[RequireComponent(typeof(CardboardStartup), typeof(TrackedPoseDriver), typeof(CameraRaycaster))]
	public class SceneCamera : MonoBehaviour
	{
		public static SceneCamera instance { get; private set; }
		public CameraRaycaster raycaster { get; private set; }
		public Camera mainCamera { get; private set; }

		void Awake()
		{
			Camera[] g = GameObject.FindObjectsOfType<Camera>();
			if (g.Length > 1) { Destroy(gameObject); return; }

			instance = this;
			mainCamera = GetComponent<Camera>();
			raycaster = GetComponent<CameraRaycaster>();
		}

		private void Start()
		{
			//Components only work in Android
			if(!InputHandler.onCardboard)
			{
				GetComponent<CardboardStartup>().enabled = false;
				GetComponent<TrackedPoseDriver>().enabled = false;
			}
		}
	}
}