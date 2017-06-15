using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour {


    private GameObject spawner;
    public Text attackText;
    private bool faded = true;
    private float fadedelay = 2.0f;
    private float timer = 0;
    public void Start()
    {
        attackText = GetComponent<Text>();
        spawner = GameObject.FindGameObjectWithTag("HPS");
    }
    public void OnTriggerEnter(Collider other)
    {

        attackText = GameObject.FindGameObjectWithTag("PickupText").GetComponent<Text>();
        attackText.text = "Health Increased";
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBehavior>().PlayerHealth += 15;
            Destroy(GetComponent<SphereCollider>());
            attackText.CrossFadeAlpha(1, 1, true); //in
            faded = false;
            spawner.GetComponent<PickUpSpawner>().pickedUp = true;
            spawner.GetComponent<PickUpSpawner>().timer = 90.0f;
        }
    }
    // Update is called once per frame
    void Update ()
    {
        if (faded == false)
        {
            timer += Time.deltaTime;
            if (timer >= fadedelay)
            {
                attackText.CrossFadeAlpha(0, 1, true); //out
                faded = true;
                Destroy(gameObject);
            }
        }
    }
}
