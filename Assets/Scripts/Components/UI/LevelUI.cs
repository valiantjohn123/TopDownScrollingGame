using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Toggle Toggle
    {
        get
        {
            return toggle;
        }
    }

    [SerializeField]
    private Text levelNo;

    private Toggle toggle;
    private int index;

    /// <summary>
    /// Mono awake
    /// </summary>
    public void SetUp(int ind)
    {
        index = ind;
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleClicked);

        levelNo.text =  index.ToString();
    }

    /// <summary>
    /// On toggle clicked
    /// </summary>
    /// <param name="value"></param>
    public void OnToggleClicked(bool value)
    {
        Debug.LogError("Toafadsd " + value +" : "  + index);
        if(value)
            Global.CurrentGame.CurrentLevel = index;
    }
}
