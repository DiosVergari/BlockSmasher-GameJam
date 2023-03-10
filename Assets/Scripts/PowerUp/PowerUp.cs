using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    // Public Variables //
    public PowerUpScriptableObject PowerUpInfo;

    // Private Variables //
    private SpriteRenderer _Sp;
    private IPowerUp _Power;

    void Awake()
    {
        sbyte rand = (sbyte)Random.Range(0, PowerUpInfo.PowerUpObject.Count);

        _Sp = GetComponent<SpriteRenderer>();
        _Power = PowerUpInfo.PowerUpObject[rand].GetComponent<IPowerUp>();
        _Sp.sprite = PowerUpInfo.PowerUpSprites[rand];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerCollision();

        if (collision.gameObject.tag == "GameOver")
            Destroy(gameObject);
    }

    private void PlayerCollision()
    {
        _Power.GivePowerUp();
        AudioManager.Instance.GoodSFX();
        Destroy(gameObject);
    }
}
