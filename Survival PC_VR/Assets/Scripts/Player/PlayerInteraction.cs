using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerDetector))]
public class PlayerInteraction : MonoBehaviour
{
	PlayerDetector detector;
	[SerializeField] DetectableCanvas detectableCanvas;

	private void Start()
	{
		if(detectableCanvas == null) { PrintConsole.Error("DetectableCanvas not defined"); }

		detector = GetComponent<PlayerDetector>();
		detector.AddObserver(OnDetected);
	}

	private void OnDisable()
	{
		detector.RemoveObserver(OnDetected);
	}

	public void OnDetected(IDetectable detected)
	{
		detectableCanvas.SetName("");
		detectableCanvas.SetHint("");
		
		if (detected == null) { return; }
		detectableCanvas.SetName(detected.name);
		
		IInteractable interactable = detected as IInteractable;
		if (interactable == null) { return; }
		detectableCanvas.SetHint(interactable.actionHint);

		if (InputHandler.auxiliary) { interactable.Interact(); }
	}
}