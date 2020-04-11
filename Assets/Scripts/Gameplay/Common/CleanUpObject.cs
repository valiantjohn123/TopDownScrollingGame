using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To clean up objects outside screen
/// </summary>
public class CleanUpObject : MonoBehaviour
{
    private bool enteredScreen;

    /// <summary>
    /// Mono update
    /// </summary>
    void Update()
    {
        if (!ScreenPositionUtility.InScreen(transform.position, Vector2.one * 2))
        {
            if(enteredScreen)
            Destroy(gameObject);
        }
        else
        {
            enteredScreen = true;
        }
    }
}
