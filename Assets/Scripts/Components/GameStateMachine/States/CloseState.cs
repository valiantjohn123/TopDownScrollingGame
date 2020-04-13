using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Closes the state when button clicked
/// </summary>
[RequireComponent(typeof(Button))]
public class CloseState : MonoBehaviour
{
    private Button closeButton;

    /// <summary>
    /// Mono start
    /// </summary>
    private void Start()
    {
        closeButton = GetComponent<Button>();
        closeButton.onClick.AddListener(ButtonClicked);
    }

    /// <summary>
    /// On button clicked trigger
    /// </summary>
    private void ButtonClicked()
    {
        DependencyHolder.MainStateController.CloseState();
    }

    /// <summary>
    /// Mono destroy
    /// </summary>
    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(ButtonClicked);
    }
}
