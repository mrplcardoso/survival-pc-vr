using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[SerializeField] StatData[] stats;
	[SerializeField] StatVisualizer[] visualizers;
	Dictionary<StatType, StatData> statMap;
	Dictionary<StatType, StatVisualizer> visualizerMap;

	private void Awake()
	{
		statMap = new Dictionary<StatType, StatData>();
		visualizerMap = new Dictionary<StatType, StatVisualizer>();
		for(int i = 0; i < stats.Length; i++)
		{
			stats[i].Initialize();
			statMap.Add(stats[i].type, stats[i]);
			visualizerMap.Add(stats[i].type, visualizers[i]);
		}
	}

	public void AddConnection(AttributeData attribute)
	{
		attribute.DependencieValue += ConnectionValue;
	}

	public void RemoveConnection(AttributeData attribute)
	{
		attribute.DependencieValue -= ConnectionValue;
	}

	public float ConnectionValue(StatType[] type, float connectionCost)
	{
		float f = 0;
		for(int i = 0; i < type.Length;i++)
		{
			f += statMap[type[i]].Use(connectionCost);
			visualizerMap[type[i]].fillAmount = statMap[type[i]].percent;
		}
		return f;
	}
}