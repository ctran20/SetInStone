using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    GameObject gameManager;
    [SerializeField] int triggerLabel = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            gameManager.GetComponent<GameManager>().areaTrigger(triggerLabel);
            Destroy(gameObject);
        }
    }
}
