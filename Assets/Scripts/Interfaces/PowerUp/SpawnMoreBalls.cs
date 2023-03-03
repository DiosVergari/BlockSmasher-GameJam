using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoreBalls : MonoBehaviour,  IPowerUp
{
    public GameObject BallSpawn;

    public void GivePowerUp()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        List<GameObject> gball = new List<GameObject>();
        GameObject ball1 = Instantiate(BallSpawn, player.transform.position, Quaternion.identity);
        GameObject ball2 = Instantiate(BallSpawn, player.transform.position, Quaternion.identity);

        gball.Add(ball1);
        gball.Add(ball2);

        for(int i = 0; i < gball.Count; i++)
        {
            Vector2 newPropul = new Vector2(Random.Range(1, 6), Random.Range(1, 6));
            gball[i].GetComponent<Rigidbody2D>().AddForce(newPropul, ForceMode2D.Impulse);

            Ball script = gball[i].GetComponent<Ball>();
            script.SetPlayerLives(player.GetComponent<Lives>());
            script.SetPlayerPoints(player.GetComponent<Points>());
        }
    }
}
