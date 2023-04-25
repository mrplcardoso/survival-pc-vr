using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AttributeData
{
	[SerializeField] AttributeType attributeType;
	public AttributeType type => attributeType;

	[SerializeField] StatType[] dependencies;
	public StatType[] statDependencies => dependencies;

	[SerializeField] float baseValue, costValue;
	public Func<StatType[], float, float> DependencieValue;

	public float value
	{
		get
		{
			if (DependencieValue == null) { return baseValue; }
			return baseValue + DependencieValue(dependencies, costValue);
		}
	}
}