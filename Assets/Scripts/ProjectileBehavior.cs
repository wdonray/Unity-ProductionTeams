using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileBehavior : MonoBehaviour, IDamager
{

    private int _attackPower = 5;
    public IDamageable minion;

    private void Start()
    {
    }

    public int AttackPower
    {
        get { return _attackPower; }
        set { _attackPower = value; }
    }

    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(AttackPower);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyBehavior>().Health <= 0)
            {
                return;
            }
            DoDamage(other.gameObject.GetComponent<EnemyBehavior>().Minion);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        this.transform.Rotate(360 * Time.deltaTime, 0, 0);
        Debug.Log(AttackPower);
    }


}
