using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Score UI handler
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI textBox;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        Global.CurrentGame.ScoreUpdated += OnScoreUpdated;
    }

    /// <summary>
    /// Score updated trigger
    /// </summary>
    /// <param name="score"></param>
    private void OnScoreUpdated(int score)
    {
        textBox.text = "Score: " + score.ToString();
    }

    /// <summary>
    /// Mono on destroyed
    /// </summary>
    private void OnDestroy()
    {
        Global.CurrentGame.ScoreUpdated -= OnScoreUpdated;
    }
}
