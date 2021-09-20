using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem hitAnimation;

    void Start()
    {

        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent(){
        if (target == null) return;
        target.TakeDamage(damage);
        if (hitAnimation ) hitAnimation.Play();

        Debug.Log("Hit");
    }
}
