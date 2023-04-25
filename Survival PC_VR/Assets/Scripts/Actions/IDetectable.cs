using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface para implementação de objetos detectáveis
public interface IDetectable
{
	//Na herança de interface, os objetos herdeiros
	//devem implementar tudo o que for declarado 
	//na interface pai
	public string name { get; }
}
