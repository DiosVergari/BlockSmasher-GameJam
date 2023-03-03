using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public GameObject[] LevelsObj;
    private sbyte Level = 0;

    public sbyte GetLevel() => Level;

    public void SetLevel(sbyte value) => Level = value;
}
