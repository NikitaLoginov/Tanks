using System;
using UnityEngine;

public class EventBroker : MonoBehaviour
{
    public static event Action FireWeaponHandler;
    public static event Action SwitchWeaponsUpHandler;
    public static event Action SwitchWeaponsDownHandler;
    public static event Action GameOverHandler;
    public static event Action StartEnemyTankHandler;
    
    //UI
    public static event Action RestartButtonHandler;
    public static event Action QuitButtonHandler;
    public static event Action StartButtonHandler;

    public static void CallFireWeapon()
    {
        FireWeaponHandler?.Invoke();
    }

    public static void CallSwitchWeaponsUp()
    {
        SwitchWeaponsUpHandler?.Invoke();
    }

    public static void CallSwitchWeaponsDown()
    {
        SwitchWeaponsDownHandler?.Invoke();
    }

    public static void CallGameOver()
    {
        GameOverHandler?.Invoke();
    }

    public static void CallStartEnemyTank()
    {
        StartEnemyTankHandler?.Invoke();
    }

    //UI
    public static void CallRestartGame()
    {
        RestartButtonHandler?.Invoke();
    }

    public static void CallQuitGame()
    {
        QuitButtonHandler?.Invoke();
    }

    public static void CallStartGame()
    {
        StartButtonHandler?.Invoke();
    }
}
