using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : LevelController
{
  [SerializeField] private int currentLevel;
  [SerializeField] private List<GameObject> levels;
  [SerializeField] private GameObject[] requiredPrefabs;

  private GameObject currentLevelObject;
  private List<GameObject> levelObjects;

  void Start()
  {
    levelObjects = new List<GameObject>();
    LoadNewLevel();
  }

  public void LevelComplete()
  {
    currentLevel++;
    LoadNewLevel();
  }

  public GameObject getCurrentLevel(int levelNo)
  {
    string currlevel = "Level" + levelNo;
    foreach (GameObject level in levels)
    {
      if (level.name == currlevel)
      {
        return level;
      }
    }
    GameOver();
    return null;
  }

  public void LoadNewLevel()
  {
    DeleteLevelObjects();
    InstantiateRequiredGameObjects();
    DestroyImmediate(currentLevelObject);
    currentLevelObject = Instantiate(getCurrentLevel(currentLevel), this.transform);
  }

  public void LoadNewLevel(int level)
  {
    DeleteLevelObjects();
    InstantiateRequiredGameObjects();
    DestroyImmediate(currentLevelObject);
    currentLevelObject = Instantiate(getCurrentLevel(level), this.transform);
  }

  private void InstantiateRequiredGameObjects()
  {
    foreach (GameObject prefab in requiredPrefabs)
    {
      levelObjects.Add(Instantiate(prefab));
    }
  }

  private void DeleteLevelObjects()
  {
    foreach (GameObject prefab in levelObjects)
    {
      DestroyImmediate(prefab);
    }
  }

  private void GameOver()
  {
    throw new NotImplementedException();
  }
}
