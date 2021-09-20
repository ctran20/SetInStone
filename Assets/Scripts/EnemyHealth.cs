﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] GameObject body;
    [SerializeField] GameObject deadAnimation;
    CapsuleCollider collidr;

    bool isDead = false;

    void Start(){
        collidr = GetComponent<CapsuleCollider>();
    }

    public bool IsDead(){
        return isDead;
    }

    public void TakeDamage(float damage){
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints < 0 && !isDead){
            Die();
            collidr.enabled = false;
            Destroy(gameObject, 4f);
        }
    }

    private void Die()
    {
        if(deadAnimation){
            deadAnimation.SetActive(true);
            Destroy(body);
        }

        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }
}
