using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game and player data
/// </summary>
public class Global
{
    /// <summary>
    /// Current game data
    /// </summary>
    public static class CurrentGame
    {
        public static Action<int> ScoreUpdated;

        public static int Score
        {
            get => score; set
            {
                ScoreUpdated?.Invoke(value);
                score = value;
            }
        }
        private static int score;

        /// <summary>
        /// Save data
        /// </summary>
        public static void SaveData()
        {
            TotalScore += Score;
        }

        /// <summary>
        /// Reset previous data
        /// </summary>
        public static void Reset()
        {
            Score = 0;
        }
    }

    /// <summary>
    /// Total score that is saved
    /// </summary>
    public static int TotalScore
    {
        get
        {
            return PlayerPrefs.GetInt("Scrte", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Scrte", value);
        }
    }
}
