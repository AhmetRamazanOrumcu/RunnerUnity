using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Tile lightTilePrefab;
    public Tile darkTilePrefab;
    private GameObject _currentLevel;
    private int _lastTileIndex;

    public List<Tile> _tiles = new List<Tile>();

   
    public void DeleteCurrentLevel()
    {
        if(_currentLevel)
        {
            Destroy(_currentLevel);
        }
    }
    public void CreateLevel()
    {
        _lastTileIndex = 0;
        _currentLevel = new GameObject("Map");
        CreateTiles(30);
    }

    public void CreateTiles(int Count)
    {
        Tile newTile;
        for (int i = 0; i < Count; i++)
        {
            if(_lastTileIndex % 2==0)
            {
                newTile = Instantiate(lightTilePrefab,_currentLevel.transform);

            }
            else
            { 
                newTile = Instantiate(darkTilePrefab,_currentLevel.transform);
            }
            newTile.transform.position = new Vector3(0, 0, _lastTileIndex * 5);
            _tiles.Add(newTile);
            _lastTileIndex += 1;
            if(_lastTileIndex<10)
            {
                newTile.SetObstacle(false);
            }
            else
            {
                if (UnityEngine.Random.value < .3f)
                {
                    newTile.SetObstacle(true);
                }
                else
                {
                    newTile.SetObstacle(false);
                }
            }
            

        }
    }
    public void MoveTile()
    {
        

        Tile newTile = _tiles[0];
        newTile.transform.position = new Vector3(0, 0, _lastTileIndex * 5);
        _tiles.Add(newTile);
        _lastTileIndex += 1;
        _tiles.RemoveAt(0);

        if (UnityEngine.Random.value < .3f)
        {
            newTile.SetObstacle(true);
        }
        else
        {
            newTile.SetObstacle(false);
        }
    }

    public float GetLastTilePosition()
    {
        return (_lastTileIndex * 5)-5;
    }
}
