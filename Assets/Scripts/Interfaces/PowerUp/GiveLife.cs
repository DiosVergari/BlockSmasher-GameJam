using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLife : MonoBehaviour, IPowerUp
{
    public void GivePowerUp()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Player.GetComponent<Lives>().GiveLife();
    }
}
