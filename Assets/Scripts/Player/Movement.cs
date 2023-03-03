using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Public Variables //
    public PlayerInfo PlayerInfo;

    // Private Variables //
    private Lives _Lives;
    private GameObject lostobj;
    private GameObject wonobj;

    private void Start()
    {
        _Lives = GetComponent<Lives>();

        lostobj = GameObject.FindGameObjectWithTag("LostScreen");
        wonobj = GameObject.FindGameObjectWithTag("WonScreen");

        lostobj.SetActive(false);
        wonobj.SetActive(false);
    }

    #region Sets
    public void SetLostActive() => lostobj.SetActive(true);

    public void SetWonActive() => wonobj.SetActive(true);
    #endregion

    #region Inputs
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
    #endregion
}
