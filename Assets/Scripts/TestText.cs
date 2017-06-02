using UnityEngine;

public class TestText : MonoBehaviour
{
    public Transform Target;
    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(Target);
        //Debug.DrawLine(transform.position, Camera.main.transform.position);
    }
}