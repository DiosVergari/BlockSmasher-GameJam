using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PowerUpInfo")]
public class PowerUpScriptableObject : ScriptableObject
{
    public List<GameObject> PowerUpObject = new List<GameObject>();
    public List<Sprite> PowerUpSprites = new List<Sprite>();
}
