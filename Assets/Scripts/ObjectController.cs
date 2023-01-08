using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{


    // Number of Balls in Scene
    int counter = 1;
    [SerializeField]
    Text counterValue;

    GameObject ball;

    private void Start()
    {       
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    private void Update()
    {
        counterValue.text = "No. Of Balls:   " + counter.ToString();
    }

    // Find all balls and enable Gravity to simulate ball drop
    public void TriggerDrop()
    {
        var foundGameObjects = FindObjectOfType<SpawnObject>();

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("ball");

        foreach (GameObject spawn in allObjects)
        {
            spawn.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    // Adjust height of ball
    public void AdjustHeight(float num)
    {
        FindObjectOfType<BallEffect>().AdjustObjectHeight(num);
    }

    // Spawn new ball in scene
    public void SpawnNewBall()
    {
        FindObjectOfType<SpawnObject>().Spawn();
        // Increase Balls in Scene Counter
        counter++;
        Debug.Log("No of Balls in Scene is" + counter);
    }


}
