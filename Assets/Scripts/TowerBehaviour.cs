using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public Tower ATower;
	// Use this for initialization
	void Start ()
	{
	    ATower = ScriptableObject.CreateInstance<Tower>();
	}
}
