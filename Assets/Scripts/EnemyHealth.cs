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
    AudioSource audioSrc;

    CapsuleCollider collidr;

    bool isDead = false;

    void Start(){
        collidr = GetComponent<CapsuleCollider>();
        audioSrc = GetComponent<AudioSource>();
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
            audioSrc.PlayOneShot(Resources.Load<AudioClip>("metal-impact"), 0.2f);
        }else if (enemyType == EnemyType.Drone)
        {
            audioSrc.PlayOneShot(Resources.Load<AudioClip>("explosion"), 0.3f);
        }
        else if(enemyType == EnemyType.BigBot){
            audioSrc.PlayOneShot(Resources.Load<AudioClip>("explosion"), 0.3f);
            audioSrc.PlayOneShot(Resources.Load<AudioClip>("electricity"), 0.3f);
        }

        if (deadAnimation){
            deadAnimation.SetActive(true);
            Destroy(body);
        }
        audioSrc.pitch = 1;
        GetComponent<Animator>().SetTrigger("die");
        isDead = true;
    }
}
