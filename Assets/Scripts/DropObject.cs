using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    Rigidbody body;
    GameObject newSpawn;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    // Alternate Way to drop ball
    public void ApplyGravity()
    {
        body.useGravity = true;
        Debug.Log("Gravity Applied!");
    }
    
    // Alternate Way to Spawn object
    public void ReturnToHeight()
    {
        newSpawn = Instantiate(gameObject, transform.position, transform.rotation);
        body.useGravity = false;
        Debug.Log("Zero Gravity");
    }
    
        
}
