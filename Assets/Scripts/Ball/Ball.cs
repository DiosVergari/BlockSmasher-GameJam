using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Public Variables //
    public BallInfo BallInfo;
    public GameObject PowerUp;

    // Private Variables //
    private Vector3 _InitialPos;
    private Points _PlayerPoints;
    private Lives   _PlayerLives;
    private Levels _PlayerLevels;
    private Rigidbody2D _RigidBody2D;


    void Start()
    {
        StartPlayer();
        StartForce();
        _InitialPos = transform.position;
    }

    #region StartFunctions
    private void StartPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _PlayerPoints = player.GetComponent<Points>();
        _PlayerLives = player.GetComponent<Lives>();
        _PlayerLevels = player.GetComponent<Levels>();
    }

    private void StartForce()
    {
        _RigidBody2D = GetComponent<Rigidbody2D>();
        Vector2 start = new Vector2(Random.Range(3, BallInfo.StartVelocity.x), Random.Range(3, BallInfo.StartVelocity.y));
        _RigidBody2D.AddForce(start, ForceMode2D.Impulse);
    }
    #endregion

    void Update()
    {
        if (_RigidBody2D.velocity.x > 8)
            _RigidBody2D.velocity = new Vector2(8, _RigidBody2D.velocity.y);

        if (_RigidBody2D.velocity.y > 8)
            _RigidBody2D.velocity = new Vector2(_RigidBody2D.velocity.x, 8);



        RaycastHit2D hit = Physics2D.Raycast(_RigidBody2D.position, _RigidBody2D.velocity.normalized, 0.5f);
    
        switch(hit.collider.gameObject.tag)
        {
            case "MainCamera":
                Debug.Log("a");
                Bounce(hit);
                break;
            case "GameOver":
                Debug.Log("b");
                Died();
                break;
            default:
                break;
        }

    }

    #region Collision
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

        _PlayerLevels.LevelsObj[_PlayerLevels.GetLevel()].SetActive(false);
        sbyte value = (sbyte)(_PlayerLevels.GetLevel() + 1);
        _PlayerLevels.SetLevel(value);

        if (_PlayerLevels.GetLevel() > _PlayerLevels.LevelsObj.Length - 1)
        {
            EndGame(true);
            return;
        }
        else
        {
            _PlayerLevels.LevelsObj[_PlayerLevels.GetLevel()].SetActive(true);
        }
    }

    private void CanSpawnPowerUp(Transform gameCol)
    {
        float rand = Random.Range(0, 1);

        if (rand > BallInfo.PowerUpChance)
            return;

        Instantiate(PowerUp, gameCol.position, Quaternion.identity);
         
    }

    private void Bounce(RaycastHit2D hit)
    {
        Vector2 newDirection = new Vector2(hit.normal.x + _RigidBody2D.velocity.x, hit.normal.y + _RigidBody2D.velocity.y);
        _RigidBody2D.velocity = newDirection;
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

        Movement playerMov = _PlayerPoints.gameObject.GetComponent<Movement>();

        if(won)
        {
            playerMov.SetWonActive();
            AudioManager.Instance.WinSFX();
        }
        else
        {
            playerMov.SetLostActive();
            AudioManager.Instance.BadSFX();
        }
    }
    #endregion

    #region Set's
    public void SetPlayerPoints(Points value) => _PlayerPoints = value;

    public void SetPlayerLives(Lives value) => _PlayerLives = value;

    #endregion
}
