using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGeneralInfo : MonoBehaviour
{
    // Public Variables //
    public BlockScriptableObject Block;

    // Private Variables //
    private bool Invincible;
    private sbyte Health;


    // Start is called before the first frame update
    void Start()
    {
        StartSprite();
        StartHealth();
        StartInvincibility();
    }

    private void StartSprite()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();

        if (Block.Invincible)
        {
            int rand = (int)Random.Range(0, Block.InvinciblebleSprites.Count - 1);
            sp.sprite = Block.InvinciblebleSprites[rand];
        }
        else
        {
            int rand = (int)Random.Range(0, Block.DestroyableSprites.Count);
            sp.sprite = Block.DestroyableSprites[rand];
        }
    }

    private void StartHealth() => Health = Block.Health;

    private void StartInvincibility() => Invincible = Block.Invincible;

    public void DealDamage() => Health--;

    public sbyte GetHealth() => Health;
}
