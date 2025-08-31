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
        _currentLevel = new GameObject("Map");
        CreateTiles(30);
    }

    public void CreateTiles(int Count)
    {
        GameObject newTile;
        for (int i = 0; i < Count; i++)
        {
            if(_tiles.Count %2==0)
            {
                newTile = Instantiate(lightTilePrefab,_currentLevel.transform);

            }
            else
            { 
                newTile = Instantiate(darkTilePrefab,_currentLevel.transform);
            }
            newTile.transform.position = new Vector3(0, 0,_tiles.Count* 5);
            _tiles.Add(newTile);
        }
    }
    public float GetLastTilePosition()
    {
        return (_tiles.Count * 5)-5;
    }
}
