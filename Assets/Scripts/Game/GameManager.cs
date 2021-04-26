using UnityEngine;
using Core;

public class GameManager : MonoBehaviour
{
  #region Private Variables

  private ObjectPooler objectPooler;

  #endregion

  internal void Initialize(GameObject player, Transform PLAYER_ROOT, GameObject[] obstacles, Transform PLATFORM_ROOT, int poolCount, int visibleObstacles, float distanceBetweenObstacles, Transform parentTransform, Transform generationPoint)
  {
    //Init Player
    player = Instantiate(player, PLAYER_ROOT);
    player.name = "PLAYER";

    //Get pooled object
    objectPooler = new ObjectPooler();


    for (int i = 0; i < poolCount; i++)
    {
      GameObject obstacle = objectPooler.GetPooledGameObject(obstacles, distanceBetweenObstacles, poolCount, PLATFORM_ROOT);

      //Debug.Log("parentTransform.position.z + (i*distanceBetweenObstacles):" + parentTransform.position.z + (i * distanceBetweenObstacles));

      //Turn it on
      if (i < visibleObstacles)
      {
        //Set position
        //obstacle.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z + (i * distanceBetweenObstacles));
        //obstacle.transform.position = generationPoint.position;
        obstacle.SetActive(true);
      }
    }
  }

  internal void GetPoolObject(Transform transform)
  {
    GameObject obstacle = objectPooler.GetPooledGameObject(transform);
    obstacle.SetActive(true);
  }
}
