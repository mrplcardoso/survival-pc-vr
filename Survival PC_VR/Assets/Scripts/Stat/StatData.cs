using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class StatData
{
	[SerializeField] StatType statType;
	public StatType type { get { return statType; } }

	[SerializeField] float maxValue, minValue = 0;
	public float current { get; private set; }
	public float percent => current / maxValue;

	public void Initialize()
	{
		current = maxValue;
	}

	public float Use(float cost)
	{
		float f = current;
		current = Mathf.Clamp(current - cost, minValue, maxValue);
		return f;
	}
}