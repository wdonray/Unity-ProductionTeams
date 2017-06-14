using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class PlayerBehavior : MonoBehaviour, IDamageable
{

    private GameObject bottle;
    public GameObject bottlePrefab;
    private int attackPower = 5;
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

    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }


    public void TakeDamage(int amount)
    {
        PlayerHealth -= amount;
    }

    public void ThrowBottle()
    {
		bottle = Instantiate(bottlePrefab, new Vector3(transform.position.x, transform.position.y + 6, transform.position.z), new Quaternion(0,0,0,0));
        Physics.IgnoreCollision(GetComponent<Collider>(), bottle.GetComponent<Collider>(), true);
        bottle.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 100);
        Destroy(bottle, 5);
    }

    public void Update()
    {
        playerHp.text = PlayerHealth.ToString();

        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("attack");
        
        animator.SetInteger("health", PlayerHealth);
    }
}