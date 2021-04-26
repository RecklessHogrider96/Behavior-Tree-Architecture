using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
  [SerializeField] private EnemyConfig enemyConfig;

  private Transform playerTransform;
  private List<Cover> avaliableCovers;

  private Material material;
  private Transform bestCoverSpot;
  private NavMeshAgent agent;

  private Node topNode;

  private float _currentHealth;
  public float currentHealth
  {
    get { return _currentHealth; }
    set { _currentHealth = Mathf.Clamp(value, 0, enemyConfig.startingHealth); }
  }

  private void Awake()
  {
    agent = GetComponent<NavMeshAgent>();
    material = GetComponentInChildren<MeshRenderer>().material;
    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    GameObject[] covers = GameObject.FindGameObjectsWithTag("Cover");
    avaliableCovers = new List<Cover>();
    int i = 0;
    foreach (GameObject cover in covers)
    {
      avaliableCovers.Add(cover.GetComponent<Cover>());
      i++;
    }
  }

  private void Start()
  {
    _currentHealth = enemyConfig.startingHealth;
    ConstructBehahaviourTree();
  }

  private void ConstructBehahaviourTree()
  {
    IsCoverAvaliableNode coverAvaliableNode = new IsCoverAvaliableNode(avaliableCovers, playerTransform, this);
    GoToCoverNode goToCoverNode = new GoToCoverNode(agent, this);
    HealthNode healthNode = new HealthNode(this, enemyConfig.lowHealthThreshold);
    IsCoveredNode isCoveredNode = new IsCoveredNode(playerTransform, transform);
    ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
    RangeNode chasingRangeNode = new RangeNode(enemyConfig.chasingRange, playerTransform, transform);
    RangeNode shootingRangeNode = new RangeNode(enemyConfig.shootingRange, playerTransform, transform);
    ShootNode shootNode = new ShootNode(agent, this, playerTransform);

    Sequence chaseSequence = new Sequence(new List<Node> { chasingRangeNode, chaseNode });
    Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });

    Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvaliableNode, goToCoverNode });
    Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });
    Selector tryToTakeCoverSelector = new Selector(new List<Node> { isCoveredNode, findCoverSelector });
    Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

    topNode = new Selector(new List<Node> { mainCoverSequence, shootSequence, chaseSequence });
  }

  private void Update()
  {
    topNode.Evaluate();
    if (topNode.nodeState == NodeState.FAILURE)
    {
      SetColor(Color.red);
      agent.isStopped = true;
    }
    currentHealth += Time.deltaTime * enemyConfig.healthRestoreRate;
  }


  public void TakeDamage(float damage)
  {
    currentHealth -= damage;
  }

  public void SetColor(Color color)
  {
    material.color = color;
  }

  public void SetBestCoverSpot(Transform bestCoverSpot)
  {
    this.bestCoverSpot = bestCoverSpot;
  }

  public Transform GetBestCoverSpot()
  {
    return bestCoverSpot;
  }
}
