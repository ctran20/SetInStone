using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDie : MonoBehaviour
{
    [SerializeField ]float moveSpeed = 5.0f;
    [SerializeField] float dieTime = 1.0f;
    [SerializeField] string direction = "forward";

    void Start(){
        Destroy(gameObject, dieTime);
    }
    void Update()
    {
        switch(direction){
            case "forward":
                transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
                break;
            case "backward":
                transform.Translate(-transform.forward * moveSpeed * Time.deltaTime);
                break;
            case "right":
                transform.Translate(transform.right * moveSpeed * Time.deltaTime);
                break;
            case "left":
                transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
                break;
            case "up":
                transform.Translate(transform.up * moveSpeed * Time.deltaTime);
                break;
            case "down":
                transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
                break;
            default:
                transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
                break;
        }
    }
}
