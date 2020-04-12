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

        public static LevelDataBase LevelData 
        {
            get 
            {
                if (levelData == null)
                    levelData = Resources.Load<LevelDataBase>("LevelData/LevelData_" + CurrentLevel.ToString());

                return levelData; 
            } 
            set => levelData = value; 
        }
        private static LevelDataBase levelData;

        public static int CurrentLevel;

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
            Resources.UnloadAsset(levelData);
            LevelData = null;
            CurrentLevel = 0;
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

    /// <summary>
    /// Total score that is saved
    /// </summary>
    public static int LastUnlockedLevel
    {
        get
        {
            return PlayerPrefs.GetInt("ckedLevel", 1);
        }
        set
        {
            PlayerPrefs.SetInt("ckedLevel", value);
        }
    }
}
