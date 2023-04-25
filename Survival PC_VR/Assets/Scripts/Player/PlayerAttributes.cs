using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
	PlayerStats playerStats;

	[SerializeField] AttributeData[] attributes;
	Dictionary<AttributeType, AttributeData> attributeMap;

	public AttributeData this[AttributeType t] { get => attributeMap[t]; }

	private void Awake()
	{
		playerStats = GetComponent<PlayerStats>();
		attributeMap = new Dictionary<AttributeType, AttributeData>();
		for(int i = 0; i < attributes.Length; i++)
		{ attributeMap.Add(attributes[i].type, attributes[i]); }
	}

	private void Start()
	{
		for (int i = 0; i < attributes.Length; i++)
		{ playerStats.AddConnection(attributes[i]); }
	}
}