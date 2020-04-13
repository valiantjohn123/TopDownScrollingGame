using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Level toggles ui controller
/// </summary>
public class LevelUIController : MonoBehaviour
{
    [SerializeField]
    private LevelUI levelObject;
    [SerializeField]
    private ToggleGroup tGroup;
    [SerializeField]
    private Transform parent;

    /// <summary>
    /// Mono awaka
    /// </summary>
    public void SetLevelData()
    {
        for (int i = 0; i < Global.TotalAvailabeLevels; i++)
        {
            int index = i + 1;
            var obj = Instantiate(levelObject, parent);
            obj.SetUp(index);

            obj.Toggle.group = tGroup;
            obj.Toggle.isOn = index == Mathf.Clamp(Global.LastUnlockedLevel, 0, Global.TotalAvailabeLevels);
            obj.Toggle.interactable = index <= Global.LastUnlockedLevel;
        }
    }
}
