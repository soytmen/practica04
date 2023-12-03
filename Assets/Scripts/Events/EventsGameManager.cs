using System;
using UnityEngine;

public class EventsGameManager : MonoBehaviour
{
    // Declare events
    public static event Action OnEnterKeyPressed;
    public static event Action OnEscapeKeyPressed;

    private void Update()
    {
        // Check for key presses and invoke corresponding events
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnEnterKeyPressed?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscapeKeyPressed?.Invoke();
        }
    }
}
