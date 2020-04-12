using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level toggles ui controller
/// </summary>
public class LevelUIController : MonoBehaviour
{
    [SerializeField]
    private List<LevelUI> levelObjects;

    /// <summary>
    /// Mono awaka
    /// </summary>
    public void SetLevelData()
    {
        for (int i = 0; i < levelObjects.Count; i++)
        {
            int index = i + 1;
            levelObjects[i].SetUp(index);

            levelObjects[i].Toggle.isOn = index == Mathf.Clamp(Global.LastUnlockedLevel, 0, levelObjects.Count);
            levelObjects[i].Toggle.interactable = index <= Global.LastUnlockedLevel;
        }
    }
}
