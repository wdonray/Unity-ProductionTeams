using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeCan : MonoBehaviour
{
    public Sprite CrushedCan, NormalCan;
    private bool _isCrushed = false;

    public void ChangeCanClick()
    {
        _isCrushed = !_isCrushed;
        GetComponent<Image>().sprite = (_isCrushed) ? CrushedCan : NormalCan;
    }
}
