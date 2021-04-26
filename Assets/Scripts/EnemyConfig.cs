using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAIConfig", menuName = "ScriptableObjects/Enemy AI Configuration", order = 1)]
public class EnemyConfig : ScriptableObject
{
  [SerializeField] public float startingHealth;
  [SerializeField] public float lowHealthThreshold;
  [SerializeField] public float healthRestoreRate;

  [SerializeField] public float chasingRange;
  [SerializeField] public float shootingRange;

  //[SerializeField] private Transform playerTransform;
  //[SerializeField] private Cover[] avaliableCovers;
}
