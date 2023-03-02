using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    // Private Variables //
    private int _Lives = 0;
    private TextMeshProUGUI _LivesTXT;

    // Start is called before the first frame update
    void Start()
    {
        _Lives = GetComponent<Movement>().PlayerInfo.Lives;

        _LivesTXT = GameObject.FindGameObjectWithTag("LivesText").GetComponent<TextMeshProUGUI>();
        _LivesTXT.text = "Lives: " + _Lives.ToString();
    }

    public void Die() 
    {
        _Lives--;
        _LivesTXT.text = "Lives: " + _Lives.ToString();
    }

    public void GiveLife()
    {
        _Lives++;
        _LivesTXT.text = "Lives: " + _Lives.ToString();
    }

    public int GetLives() => _Lives;

}
