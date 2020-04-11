using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositionUtility
{
    private static Camera mainCamera;

    /// <summary>
    /// Get vector that is clamped with screen borders
    /// </summary>
    /// <param name="pos">Input position</param>
    /// <param name="offset">Output offset</param>
    /// <returns></returns>
    public static Vector2 GetClampedPosition(Vector2 pos, Vector2 offset)
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Vector2 worldBorders = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float x = pos.x;
        float y = pos.y;

        float minX = -worldBorders.x + offset.x;
        float maxX = worldBorders.x - offset.x;

        float minY = -worldBorders.y + offset.x;
        float maxY = worldBorders.y - offset.x;

        return new Vector2(Mathf.Clamp(x, minX, maxX), Mathf.Clamp(y, minY, maxY));
    }

    /// <summary>
    /// To check if object is in screen
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static bool InScreen(Vector2 pos, Vector2 offset)
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        Vector2 worldBorders = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float x = pos.x;
        float y = pos.y;

        float minX = -worldBorders.x - offset.x;
        float maxX = worldBorders.x + offset.x;

        float minY = -worldBorders.y - offset.x;
        float maxY = worldBorders.y + offset.x;

        bool inScreen = true;

        if (x > maxX || x < minX)
        {
            return false;
        }

        if (y > maxY || y < minY)
        {
            return false;
        }

        return inScreen;
    }
}
