using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestCigaretteBehaviour : MonoBehaviour
{
    public AnimationCurve ac;
    public Animator anim;
    public Text PausedText;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    IEnumerator TweenScale()
    {
        var timer = 0f;
        var startScale = transform.localScale;
        while (timer < .5f)
        {
            timer += Time.fixedDeltaTime;
            var value = ac.Evaluate(timer);
            var newscale = new Vector3(1, 1, 1) * value;
            transform.localScale = startScale + newscale;
            yield return null;
        }
        PausedText.enabled = true;
    }

    IEnumerator TweenScaleBack()
    {
        var timer = 0f;
        var totalTime = .5f;
        var startScale = transform.localScale;
        PausedText.enabled = false;
        while(timer < totalTime)
        {
            timer += Time.fixedDeltaTime;
            transform.localScale = Vector3.Lerp(startScale, new Vector3(1, 1, 1), timer/totalTime);
            yield return null;
        }
        transform.localScale = new Vector3(1, 1, 1);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        anim.SetTrigger("open");
        StartCoroutine(TweenScale());
    }
    private void OnDisable()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    public void ClosePack()
    {
        
        anim.SetTrigger("close");
        StartCoroutine(TweenScaleBack());
    }
    
}
