[System.Serializable]
public class Invertor : Node
{
  protected Node node;
  public Invertor(Node node)
  {
    this.node = node;
  }

  public override NodeState Evaluate()
  {
    switch (node.Evaluate())
    {
      case NodeState.RUNNING:
        _nodestate = NodeState.RUNNING;
        break;
      case NodeState.SUCCESS:
        _nodestate = NodeState.FAILURE;
        break;
      case NodeState.FAILURE:
        _nodestate = NodeState.FAILURE;
        break;
      default:
        break;
    }
    return _nodestate;
  }
}