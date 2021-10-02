using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0,20f,0);
    [SerializeField] float speed = 2f;

    Vector3 startingPos;

    const float tau = Mathf.PI * 2f;

    [Range(0, 1)] [SerializeField] float movementFactor;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(speed <= Mathf.Epsilon)
        {
            movementFactor = 0;
        }
        else
        {
            float cycles = Time.time / speed;
            float rawSinWave = Mathf.Sin(cycles * tau);
            movementFactor = rawSinWave / 2f + 0.5f;
        }
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
}
