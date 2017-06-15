using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeCan : MonoBehaviour
{
    public Sprite CrushedCan, NormalCan;
    private bool _isCrushed = false;

    public void OnMouseEnter()
    {
        _isCrushed = !_isCrushed;
        //GetComponent<Image>().sprite = (_isCrushed) ? CrushedCan : NormalCan;
        GetComponent<Image>().sprite = CrushedCan;
        //Debug.Log("<color=green>Enter</color>");
    }
    public void OnMouseExit()
    {
        _isCrushed = !_isCrushed;
        //GetComponent<Image>().sprite = (_isCrushed) ? CrushedCan : NormalCan;
        GetComponent<Image>().sprite = NormalCan;
        //Debug.Log("<color=red>Exit</color>");
    }
}
