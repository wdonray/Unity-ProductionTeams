using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBehavior : MonoBehaviour
{
    private float _attackCd;
    private float _attackTimer = 2.0f;
    public int Damage;

    public int Health;

    [SerializeField] private MinionCop _minion;

    private NavMeshAgent _nav;

    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _target;

    [HideInInspector] public Tower ATower;

    private float _attackRange = 2f;

    [Range(1, 10)] public int PlayerRange;

    public MinionCop Minion
    {
        get { return _minion; }
    }

    private void Awake()
    {
        _minion = ScriptableObject.CreateInstance<MinionCop>();
        ATower = ScriptableObject.CreateInstance<Tower>();
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
    }

    private void Update()
    {
        var inPlayerRange = Vector3.Distance(transform.position, _player.transform.position) < PlayerRange;
        var inTowerRange = Vector3.Distance(transform.position, _target.transform.position) < _attackRange;
        var agentstopped = _nav.isStopped;
        if (agentstopped)
            GetComponent<MeshRenderer>().material.color = Color.black;
        else
            GetComponent<MeshRenderer>().material.color = Color.white;

        if (inPlayerRange) //chase player
        {
            _nav.SetDestination(_player.transform.position);
        }
        else
        {
            //if a tower is in range
            if (inTowerRange)
            {
                _nav.isStopped = true;
                if (_attackTimer <= 0)
                {
                    _minion.DoDamage(ATower);
                    _attackTimer = _attackCd;
                }
                else
                {
                    var curColor = GetComponent<MeshRenderer>().material.color;
                    GetComponent<MeshRenderer>().material.color =
                        Color.Lerp(curColor, Color.red, _attackTimer / _attackCd);
                    _attackTimer -= Time.deltaTime;
                }
            }
            else
            {
                _nav.isStopped = false;
                //we aren't chasing player so find a tower
                _nav.SetDestination(_target.transform.position);
            }
        }
        Health = _minion.Health;
        Damage = _minion.Damage;
    }
}