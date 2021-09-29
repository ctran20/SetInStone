using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] GameObject body;
    [SerializeField] GameObject deadAnimation;
    [SerializeField] EnemyType enemyType;
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
        if(enemyType == EnemyType.Robot){
            AudioManager.PlaySound("empty_ammo", 0.2f, 1);
        }else if (enemyType == EnemyType.Drone)
        {
            AudioManager.PlaySound("explosion", 0.3f, 1);
        }
        else if(enemyType == EnemyType.BigBot){
            AudioManager.PlaySound("mustDestroy", 0.2f, 1);
        }

        if (deadAnimation){
            deadAnimation.SetActive(true);
            Destroy(body);
        }

        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }
}
