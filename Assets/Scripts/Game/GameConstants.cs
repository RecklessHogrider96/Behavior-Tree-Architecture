using UnityEngine;

[CreateAssetMenu(fileName = "GameConstants", menuName = "ScriptableObjects/Game Constants", order = 1)]
public class GameConstants : ScriptableObject
{
    public float distanceBetweenObstacles = 5f;
    public float distanceOfForwardJump = 7f;
}
