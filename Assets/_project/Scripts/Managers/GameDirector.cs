using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public QuickMenuManager quickMenuManager;

    private void Start()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        levelManager.DeleteCurrentLevel();
        levelManager.CreateLevel();
    }
}
