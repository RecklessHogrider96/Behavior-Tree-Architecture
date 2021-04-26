[System.Serializable]
public abstract class Node
{
  #region Protected Methods
  protected NodeState _nodestate;
  #endregion

  #region Public Methods
  public NodeState nodeState { get { return _nodestate; } }
  public abstract NodeState Evaluate();
  #endregion
}

public enum NodeState
{
  RUNNING,
  SUCCESS,
  FAILURE
}