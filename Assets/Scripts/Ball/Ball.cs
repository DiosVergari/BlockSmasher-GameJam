using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Public Variables //
    public BallInfo BallInfo;
    public GameObject PowerUp;
    public GameObject[] Levels;

    // Private Variables //
    private sbyte _Level = 0;
    private Vector3 _InitialPos;
    private Points _PlayerPoints;
    private Lives   _PlayerLives;
    private Rigidbody2D _RigidBody2D;
    private GameObject lostobj;
    private GameObject wonobj;

    void Awake()
    {
        lostobj = GameObject.FindGameObjectWithTag("LostScreen");
        wonobj = GameObject.FindGameObjectWithTag("WonScreen");

        lostobj.SetActive(false);
        wonobj.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _PlayerPoints = player.GetComponent<Points>();
        _PlayerLives = player.GetComponent<Lives>();

        _InitialPos = transform.position;

        _RigidBody2D = GetComponent<Rigidbody2D>();
        Vector2 start = new Vector2(Random.Range(3, BallInfo.StartVelocity.x), Random.Range(3, BallInfo.StartVelocity.y));
        _RigidBody2D.AddForce(start, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameCol = collision.gameObject;

        if (gameCol.tag == "Block")
            BlockCollision(gameCol.transform);

        if (gameCol.tag == "GameOver")
            Died();

    }

    private void BlockCollision(Transform gameCol)
    {
        BlockGeneralInfo bgi = gameCol.GetComponent<BlockGeneralInfo>();

        if (bgi == bgi.Block.Invincible)
            return;

        bgi.DealDamage();
        if (bgi.GetHealth() < 1)
        {
            _PlayerPoints.AddPoints(1);
            Destroy(gameCol.gameObject);

            if(gameCol.parent.childCount == 1)
            {
                NewLevel(gameCol);
            }
            else
            {
                CanSpawnPowerUp(gameCol);
            }
        }
    }

    private void NewLevel(Transform gameCol)
    {
        transform.position = _InitialPos;

        Levels[_Level].SetActive(false);
        _Level += 1;

        if (_Level > Levels.Length - 1)
        {
            EndGame(true);
            return;
        }
        else
        {
            Levels[_Level].SetActive(true);
        }
    }

    private void CanSpawnPowerUp(Transform gameCol)
    {
        float rand = Random.Range(0, 1);

        if (rand > BallInfo.PowerUpChance)
            return;

        Instantiate(PowerUp, gameCol.position, Quaternion.identity);
         
    }

    private void Died()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        _PlayerLives.Die();
        AudioManager.Instance.BadSFX();
        transform.position = _InitialPos;
        _RigidBody2D.velocity = new Vector2(0, 0);
        _RigidBody2D.AddForce(BallInfo.StartVelocity, ForceMode2D.Impulse);

        if (_PlayerLives.GetLives() < 1)
        {
            EndGame(false);
            return;
        }
    }

    private void EndGame(bool won)
    {
        Time.timeScale = 0;

        if(won)
        {
            wonobj.SetActive(true);
            AudioManager.Instance.WinSFX();
        }
        else
        {
            lostobj.SetActive(true);
            AudioManager.Instance.BadSFX();
        }
    }

}
