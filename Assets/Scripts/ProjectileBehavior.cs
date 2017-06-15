using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProjectileBehavior : MonoBehaviour, IDamager
{

    //private int _attackPower = 5;
    private AudioSource bottleSound;
    public AudioClip breakSound;
    private IDamageable defender;
    private GameObject playerPower;
    private void Start()
    {
        bottleSound = GetComponent<AudioSource>();
        bottleSound.clip = breakSound;
         playerPower = GameObject.FindGameObjectWithTag("Player");
    }

    public void DoDamage(IDamageable defender)
    {
        defender.TakeDamage(playerPower.GetComponent<PlayerBehavior>().AttackPower);
    }
    public class DamageEvent : UnityEvent<GameObject> { }
    public DamageEvent OnDamaged = new DamageEvent();
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            defender = other.gameObject.GetComponent<EnemyBehavior>().Minion;
            DoDamage(defender);
            bottleSound.clip = breakSound;
            bottleSound.Play();
        }
        else
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);    
    }

    public void Update()
    {
        this.transform.Rotate(360 * Time.deltaTime, 0, 0);
    }


}
