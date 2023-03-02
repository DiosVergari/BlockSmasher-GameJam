using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BlockInfo")]
public class BlockScriptableObject : ScriptableObject
{
    [Header("The Order of Variables Configure a Memory Optimization")]
    [Header("Health Area")]
    public bool     Invincible = false;
    public sbyte    Health; // sbyte is equivalent to INT8
    public List<Sprite> DestroyableSprites;
    public List<Sprite> InvinciblebleSprites;
}
