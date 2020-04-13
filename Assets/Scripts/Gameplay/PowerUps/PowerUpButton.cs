using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Powerup button controller
/// </summary>
public class PowerUpButton : MonoBehaviour
{
    private PowerUps.PowerUpData powerUpData;

    [SerializeField]
    private Image chargeIndicator;
    [SerializeField]
    private Text powerUpText;

    private bool fullyCharged;

    /// <summary>
    /// Set the powerup data
    /// </summary>
    /// <param name="data"></param>
    public void SetUpData(int index, PowerUps.PowerUpData data)
    {
        powerUpText.text = "P" + (index+1);
        powerUpData = data;
        StartCoroutine(ChargePowerUp());
    }

    /// <summary>
    /// Charge the powerup
    /// </summary>
    /// <returns></returns>
    IEnumerator ChargePowerUp()
    {
        float timer = 0;
        while (timer <= powerUpData.ChargeTime)
        {
            chargeIndicator.fillAmount = timer / powerUpData.ChargeTime;
            timer += Time.deltaTime;
            yield return null;
        }

        chargeIndicator.fillAmount = 1;
        fullyCharged = true;
    }

    /// <summary>
    /// Discharge powerup
    /// </summary>
    /// <returns></returns>
    IEnumerator DischargePowerUp()
    {
        fullyCharged = false;
        float timer = 0;
        while (timer <= powerUpData.ExpireTime)
        {
            chargeIndicator.fillAmount = 1-(timer / powerUpData.ExpireTime);
            timer += Time.deltaTime;
            yield return null;
        }

        chargeIndicator.fillAmount = 0;
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(ChargePowerUp());
    }

    /// <summary>
    /// Use the powerup
    /// </summary>
    public void UsePowerUp()
    {
        if (fullyCharged)
        {
            PlayerAbilityHandler.UseAbility?.Invoke(powerUpData);
            StartCoroutine(DischargePowerUp());
        }
    }
}
