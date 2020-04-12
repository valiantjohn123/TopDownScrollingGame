using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score UI handler
/// </summary>
[RequireComponent(typeof(Text))]
public class ScoreUI : MonoBehaviour
{
    private Text textBox;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        textBox = GetComponent<Text>();
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
