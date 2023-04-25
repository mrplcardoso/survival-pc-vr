using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface para implementacao de objetos interagiveis
public interface IInteractable : IDetectable
{
	//Na heran�a de interface, os objetos herdeiros
	//devem implementar tudo o que for declarado 
	//na interface pai
	public string actionHint { get; }

	public void Interact();
}
