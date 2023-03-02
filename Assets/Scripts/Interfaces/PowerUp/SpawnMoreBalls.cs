using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoreBalls : MonoBehaviour,  IPowerUp
{
    public void GivePowerUp()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        Instantiate(ball);
        Instantiate(ball);
    }
}
