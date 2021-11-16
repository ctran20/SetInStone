using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnTimer : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        StartCoroutine(TurnOn());
    }

    IEnumerator TurnOn(){
        yield return new WaitForSeconds(time);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(true);
        }
    }
}
