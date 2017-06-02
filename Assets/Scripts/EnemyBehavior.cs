using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//[RequireComponent(typeof(Rigidbody))]
public class EnemyBehavior : MonoBehaviour
{
    private float _attackCd;

    private float _attackRange = 2f;
    private float _attackTimer = 2.0f;

    private AudioSource _enemyAudio;

    [SerializeField] private MinionCop _minion;

    private NavMeshAgent _nav;

    [SerializeField] private GameObject _player, _target;

    [HideInInspector] public Tower ATower;

    public Text CopHpText;

    public int Damage, Health;

    public AudioClip DeathClip, AttackClip;

    [Range(1, 10)] public int PlayerRange;

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

        Health = _minion.CopHealth;
        Damage = _minion.CopDamage;
        _attackRange = _nav.stoppingDistance;
        ATower = _target.GetComponent<TowerBehaviour>().ATower;
    }

    public void Sink()
    {
        StartCoroutine(ThroughFloor());
        _nav.enabled = false;
        GetComponent<Collider>().isTrigger = true;
        Destroy(gameObject, 2f);
        SpawnerRef = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        SpawnerRef.TheCops.Remove(gameObject);
    }

    public void TargetPlayer()
    {
        transform.LookAt(_player.transform.position);
        Debug.DrawLine(transform.position, _player.transform.position, Color.yellow);
        _nav.SetDestination(_player.transform.position);
    }

    public void TargetTower()
    {
        transform.LookAt(_target.transform.position);
        Debug.DrawLine(transform.position, _target.transform.position, Color.blue);
        //we aren't chasing player so find a tower
        _nav.SetDestination(_target.transform.position);
    }

    private void Update()
    {
        var inPlayerRange = Vector3.Distance(transform.position,
                                _player.transform.position) < PlayerRange;
        var inTowerRange = Vector3.Distance(transform.position,
                               _target.transform.position) < _attackRange;
        if (inPlayerRange) //chase player
        {
            TargetPlayer();
        }
        else
        {
            if (Health <= 0)
            {
                if (!_enemyAudio.isPlaying)
                {
                    _enemyAudio.clip = DeathClip;
                    _enemyAudio.Play();
                }
                Sink();
            }
            //if a tower is in range
            else if (inTowerRange)
            {
                if (_attackTimer <= 0)
                {
                    _minion.DoDamage(ATower);
                    if (!_enemyAudio.isPlaying)
                    {
                        _enemyAudio.clip = AttackClip;
                        _enemyAudio.Play();
                    }
                    _attackTimer = _attackCd;
                }
                else
                {
                    _attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                TargetTower();
            }

            CopHpText = gameObject.GetComponentInChildren<Text>();
            CopHpText.text = Minion.CopHealth.ToString();
        }
        Health = _minion.CopHealth;
        Damage = _minion.CopDamage;
    }

    private IEnumerator ThroughFloor()
    {
        while (true)
        {
            transform.position -= new Vector3(0, .01f, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}