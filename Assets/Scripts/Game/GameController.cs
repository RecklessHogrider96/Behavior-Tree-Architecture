using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Variables
    private GameManager gameManager;

    [Header("Main References")]
    //The Main Obstacle
    public Transform Enemies_Root;
    public GameObject[] obstacles;
    public int poolCount;

    //The Main Player
    public Transform PLAYER_ROOT;
    public GameObject player;
    
    //Visible obstacles in View
    public int visibleObstacles;

    //Game Constants
    public GameConstants gameConstants;

    //Generation Point
    public Transform generationPoint;

    #endregion

    private void Awake()
    {
        gameManager = new GameManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager.Initialize(player, 
          PLAYER_ROOT, 
          obstacles, 
          Enemies_Root, 
          poolCount, 
          visibleObstacles, 
          gameConstants.distanceBetweenObstacles, 
          this.transform, 
          generationPoint);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Check if generation point is inside the screen 
        //if (PLATFORM_ROOT.position.sqrMagnitude > generationPoint.position.z)
        //{
        //    Debug.Log("GENERATE NEW PLATFORM");
        //    if (onChange)
        //    {
        //        onChange = false;
        //        gameManager.GetPoolObject(this.transform);
        //    }
        //}
    }
}
