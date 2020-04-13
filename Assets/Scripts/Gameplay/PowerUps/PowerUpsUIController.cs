using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsUIController : MonoBehaviour
{
    [SerializeField]
    private PowerUps powerUpsData;
    [SerializeField]
    private PowerUpButton powerUpButton;

    /// <summary>
    /// Mono awake
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < powerUpsData.PowerUpsList.Count; i++)
        {
            Instantiate(powerUpButton, transform).SetUpData(i, powerUpsData.PowerUpsList[i]);
        }
    }
}
