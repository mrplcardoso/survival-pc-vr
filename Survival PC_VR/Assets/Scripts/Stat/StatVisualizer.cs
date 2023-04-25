using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatVisualizer : MonoBehaviour
{
	Image visualizer;
	public float fillAmount { get => visualizer.fillAmount; set => visualizer.fillAmount = value; }

	void Awake()
	{
		visualizer = GetComponentsInChildren<Image>()[1];
	}
}
