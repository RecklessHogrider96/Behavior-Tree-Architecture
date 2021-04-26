using DevGameRoshan;
using UnityEngine;

namespace Events
{
  public class NewGameClickedEvent : GameEvent
  {
    private int level;

    public NewGameClickedEvent(int level)
    {
      this.level = level;
    }

    internal int getCurrentLevel()
    {
      return level;
    }
  }
}