using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 15f;
    
    float turnSpeed = 0.4f;
    Transform target;
    EnemyHealth health;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = true;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.IsDead()){
            enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked){
            EngageTarget();
        }else if(chaseRange > distanceToTarget){
            isProvoked = true;
        }
        
    }

    public void OnDamageTaken(){
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();
        //if (distanceToTarget >= navMeshAgent.stoppingDistance)
        //{
        //    ChaseTarget();
        //}else if(distanceToTarget < navMeshAgent.stoppingDistance)
        //{
        //    AttackTarget();
        //}
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    private void ChaseTarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        //if (!health.IsDead())
        //{
        //    navMeshAgent.SetDestination(target.position);
        //}
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
