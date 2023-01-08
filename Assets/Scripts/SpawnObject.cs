using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    // Ball Prefab
    [SerializeField]
    GameObject objectPrefab;

    // Rigidbody to toggle gravity to simulate ball drop
    public Rigidbody body;

    // Height of Ball drop
    float heightValue;

    GameObject spawnedObject;

    private void Start()
    {
        body = objectPrefab.GetComponent<Rigidbody>();
    }
    
    // Alternate way to make ball drop
    public void ApplyGravity()
    {
        body.useGravity = true;
        Debug.Log("Gravity Applied!");
    }
    

    // Instantiate a new ball with height given by slider input
    public void Spawn()
    {
        heightValue = FindObjectOfType<Slider>().value;
        spawnedObject = Instantiate(objectPrefab, transform.position + transform.up * 1.0f * heightValue, transform.rotation);
    }

}
