using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] int MoveSpeed = 10;
    Vector3 target;

    int MinDist = 0;

    private void Start()
    {
        transform.LookAt(FindObjectOfType<PlayerHealth>().transform);
        target = FindObjectOfType<PlayerHealth>().transform.position;
    }

    void Update()
    {
            if (Vector3.Distance(transform.position, target) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.05f);
    }
}
