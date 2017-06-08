using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerBehavior : MonoBehaviour, IDamageable
{

    private GameObject bottle;
    public GameObject bottlePrefab;
    private int _playerHealth = 100;
    public Text playerHp;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public int PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }


    public void TakeDamage(int amount)
    {
        PlayerHealth -= amount;
    }
   

    public void ThrowBottle()
    {
        bottle = Instantiate(bottlePrefab, transform);
        bottle.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 25);
        Destroy(bottle, 5);
    }

    public void Update()
    {
        playerHp.text = PlayerHealth.ToString();
        if (PlayerHealth <= 0)
            return;

        if (Input.GetMouseButtonDown(0))
            ThrowBottle();      
        animator.SetInteger("health", PlayerHealth);
    }
}