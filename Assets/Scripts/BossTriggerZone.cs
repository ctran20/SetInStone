using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TriggerBox
{
    Front,
    Back,
    Left,
    Right
};

public class BossTriggerZone : MonoBehaviour
{
    [SerializeField] TriggerBox zone;
    [SerializeField] GameObject boss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(zone == TriggerBox.Front)
            {
                boss.GetComponent<EnemyAttack>().inFront = true;
            }
            else if (zone == TriggerBox.Left)
            {
                boss.GetComponent<EnemyAttack>().inLeft = true;
            }
            else if (zone == TriggerBox.Right)
            {
                boss.GetComponent<EnemyAttack>().inRight = true;
            }
            else
            {
                boss.GetComponent<EnemyAttack>().inBack = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zone == TriggerBox.Front)
            {
                boss.GetComponent<EnemyAttack>().inFront = false;
            }
            else if (zone == TriggerBox.Left)
            {
                boss.GetComponent<EnemyAttack>().inLeft = false;
            }
            else if (zone == TriggerBox.Right)
            {
                boss.GetComponent<EnemyAttack>().inRight = false;
            }
            else
            {
                boss.GetComponent<EnemyAttack>().inBack = false;
            }
        }
    }


}
