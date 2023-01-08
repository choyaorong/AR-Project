using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BallEffect : MonoBehaviour
{
    //Count the times the ball bounces
    int collisionCounter = 0;

    //Indicate on screen overlay
    [SerializeField]
    TextMeshPro counterValue;

    //Play bounce sound FX
    public AudioSource audioSource;

    //Height of ball
    float heightValue;

    
    private void Start()
    {
        collisionCounter = 0; // Reset bounce counter
        heightValue = FindObjectOfType<Slider>().value; 
    }

    // Determine bounce counter
    private void Update()
    {                    
        if (collisionCounter == 0)
        {
            counterValue.text = "";
        }

        else if (collisionCounter == 1)
        {
            counterValue.text = collisionCounter.ToString() + " bounce";
        }
        else
        {
            counterValue.text = collisionCounter.ToString() + " bounces";
        }
    }

    // Upon collision, ball will change to random colour, bounce sound effect and count number of bounces
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");

        //Ball changes to random colour upon collision
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),1);

        //Ensure collision with other spawn balls does not affect bounce counter
        if (!collision.gameObject.CompareTag("ball"))
        {
            collisionCounter++;
            audioSource.Play();

        }

    }

    //Adjust height of spawn ball according to slider value
    public void AdjustObjectHeight(float num)
    {
        Vector3 temp = transform.position;
        temp.y = num;
        transform.position = temp;
    }

    //Alternate way to adjust height of ball
    public void AdjustHeight()
    {
        gameObject.transform.SetPositionAndRotation(transform.position + transform.up * 1.0f * heightValue, transform.rotation);
    }
}