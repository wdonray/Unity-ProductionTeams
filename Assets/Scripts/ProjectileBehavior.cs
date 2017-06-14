using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileBehavior : MonoBehaviour, IDamager
{

    private int _attackPower = 5;
    private AudioSource bottleSound;
    public AudioClip breakSound;
    private void Start()
    {
        bottleSound = GetComponent<AudioSource>();
    }

    public int AttackPower
    {
        get { return _attackPower; }
        set { _attackPower = value; }
    }

    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(AttackPower);
        if (!bottleSound.isPlaying)
        {
            bottleSound.clip = breakSound;
            bottleSound.Play();
        }
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

    public void Update()
    {
        this.transform.Rotate(360 * Time.deltaTime, 0, 0);
    }


}
