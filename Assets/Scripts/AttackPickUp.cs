using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPickUp : MonoBehaviour
{

    private GameObject spawner;
    public Text attackText;
    public void Start()
    {
        attackText = GetComponent<Text>();
        spawner = GameObject.FindGameObjectWithTag("APS");
        attackText.CrossFadeAlpha(0, 1, true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBehavior>().AttackPower += 5;
            Destroy(gameObject);
            spawner.GetComponent<PickUpSpawner>().pickedUp = true;
            spawner.GetComponent<PickUpSpawner>().timer = 90.0f;
            StartCoroutine(Test());
        }
    }

    public IEnumerator Test()
    {
        attackText.text = "Working";
        attackText.CrossFadeAlpha(1, 1, true);
        yield return new WaitForSeconds(2);
        attackText.CrossFadeAlpha(0, 1, true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
