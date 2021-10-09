using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private float delay = 1f;
    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    [SerializeField] private float rotOffsetX;
    [SerializeField] private float rotOffsetY;
    [SerializeField] private float rotOffsetZ;
    [SerializeField] private float timer;
    [SerializeField] private GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(spawnObject, new Vector3(transform.position.x + offsetX,
                                            transform.position.y + offsetY,
                                            transform.position.z + offsetZ),
                                            new Quaternion(rotOffsetX, rotOffsetY, rotOffsetZ, 0));
        Invoke("Spawn", delay);
    }
}
