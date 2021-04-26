using DevGameRoshan;
using Events;
using UnityEngine;

public class LevelController : BaseController
{
  private LevelManager levelManager;

  void Start()
  {
    levelManager = GameObject.FindObjectOfType(typeof(LevelManager)) as LevelManager;
    RegisterEvents();
  }

  public override void RegisterEvents()
  {
    EventManager.Instance.AddListener<NewGameClickedEvent>(OnNewGameClicked);
  }

  private void OnNewGameClicked(NewGameClickedEvent e)
  {
    levelManager.LoadNewLevel(e.getCurrentLevel());
  }

  private void OnDestroy()
  {
    UnRegisterEvents();
  }

  public override void UnRegisterEvents()
  {
    //EventManager.Instance.RemoveListener<NewGameClickedEvent>(OnNewGameClicked);
  }
}