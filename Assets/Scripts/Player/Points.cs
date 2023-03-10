using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    // Private Variables //
    private sbyte _Points = 0;
    private TextMeshProUGUI _ScoreTXT;

    void Awake()
    {
        _ScoreTXT = GameObject.FindGameObjectWithTag("PointsText").GetComponent<TextMeshProUGUI>();

        _ScoreTXT.text = "Points: " + _Points.ToString();
    }

    public void AddPoints(sbyte value)
    {
        _Points += value;
        _ScoreTXT.text = "Points: " + _Points.ToString();
    }

    public int GetPoints () => _Points;
}
