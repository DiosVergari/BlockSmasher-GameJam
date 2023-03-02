using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasePlayerSize : MonoBehaviour, IPowerUp
{
    public void GivePowerUp()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 newScale = new Vector3(Player.transform.localScale.x * 0.8f, Player.transform.localScale.y, Player.transform.localScale.z);
        Player.transform.localScale = newScale;
    }
}
