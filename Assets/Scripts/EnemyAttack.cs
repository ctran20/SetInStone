using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem hitAnimation;
    [SerializeField] GameObject fireball;
    public bool inLaser = false;
    public bool inFront = false;
    public bool inBack = false;
    public bool inLeft = false;
    public bool inRight = false;

    void Start()
    {

        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent(){
        if (target == null) return;
        target.TakeDamage(damage);
        if (hitAnimation ) hitAnimation.Play();
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }

    public void BossFireEvent()
    {
        Instantiate(fireball, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+10, gameObject.transform.position.z+2) , new Quaternion(0, 0, 0, 0));
    }

    public void BossLaserHitEvent()
    {
        if (target == null || !inLaser) return;
        target.TakeDamage(5);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
