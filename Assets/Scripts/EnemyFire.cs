using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] int MoveSpeed = 10;
    Vector3 target;
    GameObject player;

    int MinDist = 0;

    private void Start()
    {
        Destroy(gameObject, 4f);
        transform.LookAt(FindObjectOfType<PlayerHealth>().transform);
        player = FindObjectOfType<PlayerHealth>().gameObject;
        target = player.transform.position;
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
        player.GetComponent<PlayerHealth>().TakeDamage(20f);
        Destroy(gameObject, 0.05f);
    }
}
