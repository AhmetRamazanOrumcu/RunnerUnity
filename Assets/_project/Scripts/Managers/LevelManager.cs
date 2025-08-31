using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject lightTilePrefab;
    public GameObject darkTilePrefab;
    private GameObject _currentLevel;

    private List<GameObject> _tiles = new List<GameObject>();

   
    public void DeleteCurrentLevel()
    {
        if(_currentLevel)
        {
            Destroy(_currentLevel);
        }
    }
    public void CreateLevel()
    {
        CreateTiles(10);
    }

    private void CreateTiles(int Count)
    {
        GameObject newTile;
        for (int i = 0; i < Count; i++)
        {
            if(_tiles.Count %2==0)
            {
                newTile = Instantiate(lightTilePrefab);

            }
            else
            { 
                newTile = Instantiate(darkTilePrefab);
            }
            newTile.transform.position = new Vector3(0, 0, i * 5);
            _tiles.Add(newTile);
        }
    }
}
