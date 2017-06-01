using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBehaviour : MonoBehaviour
{
    public Tower ATower;

    public Text TowerHp;
	// Use this for initialization
	void Start ()
	{
	    ATower = ScriptableObject.CreateInstance<Tower>();
	    TowerHp = GameObject.FindGameObjectWithTag("TowerHP").GetComponent<Text>();
    }

    void Update()
    {
        TowerHp.text = ATower.Health.ToString();
    }
}
