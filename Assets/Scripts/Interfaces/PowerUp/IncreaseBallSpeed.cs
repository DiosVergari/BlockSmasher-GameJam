using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBallSpeed : MonoBehaviour, IPowerUp
{
    public void GivePowerUp()
    {
        GameObject[] Balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject b in Balls) 
        {
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.velocity *= 1.2f;
        }
    }
}
