using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    private NavMeshAgent _nav;

    [Range(1, 10)] public int TargetRange;

    [SerializeField] private GameObject _target;

    [SerializeField] private GameObject _player;

    // Use this for initialization
    private void Start()
    {
        _nav = GetComponent<NavMeshAgent>();
        _nav.SetDestination(_target.transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < TargetRange)
        {
            _nav.SetDestination(_player.transform.position);
        }
        else if (Vector3.Distance(this.transform.position, _target.transform.position) < TargetRange)
        {
            _nav.SetDestination(_target.transform.position);
            Destroy(this);
        }
    }
}