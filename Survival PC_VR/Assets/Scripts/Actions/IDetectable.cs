using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface para implementa��o de objetos detect�veis
public interface IDetectable
{
	//Na heran�a de interface, os objetos herdeiros
	//devem implementar tudo o que for declarado 
	//na interface pai
	public string name { get; }
}
