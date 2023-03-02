using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BallInfo")]
public class BallInfo : ScriptableObject
{
    public Vector2 StartVelocity;
    [Range(0f, 1f)]
    public float PowerUpChance;
}
