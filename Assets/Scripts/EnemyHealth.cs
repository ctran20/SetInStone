using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    CapsuleCollider collider;

    bool isDead = false;

    void Start(){
        collider = GetComponent<CapsuleCollider>();
    }

    public bool IsDead(){
        return isDead;
    }

    public void TakeDamage(float damage){
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints < 0 && !isDead){
            Die();
            collider.enabled = false;
            Destroy(gameObject, 10f);
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }
}
