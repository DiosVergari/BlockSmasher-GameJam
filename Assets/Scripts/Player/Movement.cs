using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Public Variables //
    public PlayerInfo PlayerInfo;
    private Lives _Lives;

    private void Start()
    {
        _Lives = GetComponent<Lives>();        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (_Lives.GetLives() < 1)
            return;

        if (context.performed)
        {
            Vector2 contextValue = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            transform.position = new Vector2(contextValue.x, transform.position.y);
        }
    }
}
