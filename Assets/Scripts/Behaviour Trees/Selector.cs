using System.Collections.Generic;

[System.Serializable]
public class Selector : Node
{
  protected List<Node> nodes = new List<Node>();
  public Selector(List<Node> nodes)
  {
    this.nodes = nodes;
  }

  public override NodeState Evaluate()
  {
    foreach (var node in nodes)
    {
      switch (node.Evaluate())
      {
        case NodeState.RUNNING:
          _nodestate = NodeState.RUNNING;
          return _nodestate;
        case NodeState.SUCCESS:
          _nodestate = NodeState.SUCCESS;
          return _nodestate;
        case NodeState.FAILURE:
        default:
          break;
      }
    }
    _nodestate = NodeState.FAILURE;
    return _nodestate;
  }
}