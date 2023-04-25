using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Random;

public class TestColorDetectable : MonoBehaviour, IInteractable
{
    public string actionHint => "Press 'E' or 'X' to change color";

    public void Interact()
    {
        GetComponent<MeshRenderer>().material.color = RandomStream.RGB();
    }
}
