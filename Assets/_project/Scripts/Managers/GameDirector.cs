using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;

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
