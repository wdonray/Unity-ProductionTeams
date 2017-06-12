using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    private float _attackCd;
    //private float _attackRange = 50f;
    private float _attackTimer = 2.0f;
    private AudioSource _enemyAudio;

    [SerializeField]
    private MinionCop _minion;

    private NavMeshAgent _nav;

    [SerializeField]
    private GameObject _player, _target;

    public Animator ani;

    [HideInInspector]
    public Tower ATower;

    public Text CopHpText;
    public int Damage, Health;
    public AudioClip DeathClip, AttackClip;
    [HideInInspector]
    public PlayerBehavior Player;

    [Range(1, 50)]
    public int PlayerRange;

    public EnemySpawner SpawnerRef;

    public MinionCop Minion
    {
        get { return _minion; }
    }

    private void Awake()
    {
        _minion = ScriptableObject.CreateInstance<MinionCop>();
        _attackCd = _attackTimer;
        //Time.timeScale = 10;
        _enemyAudio = GetComponent<AudioSource>();
    }

    // Use this for initialization
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _nav.SetDestination(_target.transform.position);
        _target = GameObject.FindWithTag("Target");
        _player = GameObject.FindWithTag("Player");

        Health = Minion.CopHealth;
        Damage = Minion.CopDamage;
        //_attackRange = _nav.stoppingDistance;
        ATower = _target.GetComponent<TowerBehaviour>().ATower;
        Player = _player.GetComponent<PlayerBehavior>();
    }

    //Sinks the dying enemy through the floor
    public void Sink()
    {
        StartCoroutine(ThroughFloor());
        _nav.enabled = false;
        GetComponent<Collider>().isTrigger = true;
        Destroy(gameObject, 2f);
        EnemySpawner.TheCops.Remove(gameObject);
    }

    //Sets the Target to the Player
    public void TargetPlayer()
    {
        transform.LookAt(_player.transform.position);
        Debug.DrawLine(transform.position, _player.transform.position, Color.yellow);
        _nav.SetDestination(_player.transform.position);
        ani.SetTrigger("walk");
    }

    //Sets the Target to the Tower
    public void TargetTower()
    {
        //transform.LookAt(_target.transform.position);
        Debug.DrawLine(transform.position, _target.transform.position, Color.blue);
        _nav.SetDestination(_target.transform.position);
        ani.SetTrigger("walk");
    }

    public void HitPlayer()
    {
        var inPlayerRange = Vector3.Distance(transform.position,
                                _player.transform.position) < 20;
        var inTowerRange = Vector3.Distance(transform.position,
                               _target.transform.position) < 50;
        if (inPlayerRange)
            Minion.DoDamage(Player);
        else if (inTowerRange)
            Minion.DoDamage(ATower);

        if (!_enemyAudio.isPlaying)
        {
            _enemyAudio.clip = AttackClip;
            _enemyAudio.Play();
        }
    }
    private void Update()
    {
        ani.SetInteger("health", Health);
        var inPlayerRange = Vector3.Distance(transform.position,
                                _player.transform.position) < PlayerRange;
        var inTowerRange = Vector3.Distance(transform.position,
                               _target.transform.position) < 60;
        if (Health <= 0)
        {
            Sink();
            if (!_enemyAudio.isPlaying)
            {
                _enemyAudio.clip = DeathClip;
                _enemyAudio.Play();
            }
        }
        else
        {
            if (inPlayerRange) //chase player
            {
                if (Vector3.Distance(transform.position,
                        _player.transform.position) < 20)
                {
                    ani.SetTrigger("attack");
                    _attackTimer = _attackCd;
                }
                else
                    TargetPlayer();
            }
            else if (inTowerRange)
            {
                if (Vector3.Distance(transform.position,
                    _target.transform.position) < 40)
                {
                    ani.SetTrigger("attack");
                    _attackTimer = _attackCd;
                }
            }
            else
                TargetTower();
        }
        CopHpText = gameObject.GetComponentInChildren<Text>();
        CopHpText.text = Minion.CopHealth.ToString();
        Health = Minion.CopHealth;
        Damage = Minion.CopDamage;
    }

    private IEnumerator ThroughFloor()
    {
        while (true)
        {
            transform.position -= new Vector3(0, .001f, 0);
            yield return new WaitForEndOfFrame();
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
#endif
}