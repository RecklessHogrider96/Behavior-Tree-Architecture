using Core;
using Events;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  [SerializeField] private Button Level1;
  [SerializeField] private Button Level2;
  [SerializeField] private Button Level3;
  [SerializeField] private Button quit;

  // Start is called before the first frame update
  void Start()
  {
    Level1.onClick.AddListener(loadLevel1);
    Level2.onClick.AddListener(loadLevel2);
    Level3.onClick.AddListener(loadLevel3);
    quit.onClick.AddListener(quitGame);
  }

  private void quitGame()
  {
    Application.Quit();
  }

  private void loadLevel1()
  {
    Utils.EventAsync(new NewGameClickedEvent(1));
  }

  private void loadLevel2()
  {
    Utils.EventAsync(new NewGameClickedEvent(2));
  }

  private void loadLevel3()
  {
    Utils.EventAsync(new NewGameClickedEvent(3));
  }
}
