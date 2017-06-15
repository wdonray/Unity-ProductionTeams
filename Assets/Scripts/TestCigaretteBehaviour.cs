using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCigaretteBehaviour : MonoBehaviour
{
    public AnimationCurve ac;
    IEnumerator TweenScale()
    {
        var timer = 0f;
        var startScale = transform.localScale;
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            float value = ac.Evaluate(timer);
            var newscale = new Vector3(1, 1, 1) * value;
            transform.localScale = startScale + newscale;
            yield return null;
        }
    }

    public void OpenPack()
    {
        
    }

    public void ClosePack()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(TweenScale());
    }

    private void OnDisable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
