using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBehavior : MonoBehaviour
{
    private float _attackCd;

    private float _attackRange = 2f;
    private float _attackTimer = 2.0f;

    [SerializeField] private MinionCop _minion;

    private NavMeshAgent _nav;

    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _target;

    [HideInInspector] public Tower ATower;

    public Text CopHpText;

    public int Damage;

    public int Health;

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
    }

    // Use this for initialization
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _nav.SetDestination(_target.transform.position);
        _target = GameObject.FindWithTag("Target");
        _player = GameObject.FindWithTag("Player");

        Health = _minion.Health;
        Damage = _minion.Damage;
        _attackRange = _nav.stoppingDistance;
        ATower = _target.GetComponent<TowerBehaviour>().ATower;
    }

    public void Sink()
    {
        _nav.enabled = false;
        GetComponent<Collider>().isTrigger = true;
        Destroy(gameObject, 2f);
        SpawnerRef = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        SpawnerRef.TheCops.Remove(gameObject);
    }

    private void Update()
    {
        var inPlayerRange = Vector3.Distance(transform.position,
                                _player.transform.position) < PlayerRange;
        var inTowerRange = Vector3.Distance(transform.position,
                               _target.transform.position) < _attackRange;
        if (inPlayerRange) //chase player
        {
            transform.LookAt(_player.transform.position);
            Debug.DrawLine(transform.position, _player.transform.position, Color.yellow);
            _nav.SetDestination(_player.transform.position);
        }
        else
        {
            if (Health <= 0)
                Sink();
            //if a tower is in range
            if (inTowerRange)
            {
                if (_attackTimer <= 0)
                {
                    _minion.DoDamage(ATower);
                    _attackTimer = _attackCd;
                }
                else
                {
                    _attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                transform.LookAt(_target.transform.position);
                Debug.DrawLine(transform.position, _target.transform.position, Color.blue);
                //we aren't chasing player so find a tower
                _nav.SetDestination(_target.transform.position);
            }
            CopHpText = this.gameObject.GetComponentInChildren<Text>();
            CopHpText.text = Minion.Health.ToString();
        }
        Health = _minion.Health;
        Damage = _minion.Damage;
    }
}