using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectableCanvas : MonoBehaviour
{
	TextMeshProUGUI detectableName, interactableHint;

  void Start()
  {
    SetTextFields();
  }

	void SetTextFields()
  {
		TextMeshProUGUI[] t = transform.GetComponentsInChildren<TextMeshProUGUI>();
		for (int i = 0; i < t.Length; i++)
		{
			if (t[i].CompareTag("Detectable Name")) { detectableName = t[i]; }
			if (t[i].CompareTag("Interactable Hint")) { interactableHint = t[i]; }
		}

		if (detectableName == null) { PrintConsole.Error("No field 'Detectable Name' with proper Tag found in Detectable Canvas, check tag of it's children"); }
		if (interactableHint == null) { PrintConsole.Error("No field 'Interactable Hint' with proper Tag found in Detectable Canvas, check tag of it's children"); }
	}

	public void SetName(string name)
	{
		detectableName.text = name;
	}

	public void SetHint(string hint)
	{
		interactableHint.text = hint;
	}
}
