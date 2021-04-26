using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ObjectPooler
    {
        #region Private Variables

        private List<GameObject> pooledObjects;
        private int randomIndex;

        #endregion

        #region Private Methods
        /// <summary>
        /// Fot the first time init for the Pool.
        /// </summary>
        /// <param name="poolCount"></param>
        /// <param name="pooledObject"></param>
        /// <param name="parentTransform"></param>
        private void InitializePool(int poolCount, float distanceBetweenObstacles, GameObject[] pooledObject, Transform parentTransform)
        {
            pooledObjects = new List<GameObject>();

            for (int i = 0; i < poolCount; i++)
            {
                GameObject obj = null;

                if (i < pooledObject.Length)
                    obj = Object.Instantiate(pooledObject[i], parentTransform);
                else
                    obj = Object.Instantiate(pooledObject[pooledObject.Length - 1], parentTransform);

                if (obj != null)
                {
                    obj.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z + (i * distanceBetweenObstacles));
                    pooledObjects.Add(obj);
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To get the required poolobject.
        /// </summary>
        /// <param name="pooledObject"></param>
        /// <param name="poolCount"></param>
        /// <param name="parentTransform"></param>
        /// <returns></returns>
        public GameObject GetPooledGameObject(GameObject[] pooledObject, float distanceBetweenObstacles, int poolCount, Transform parentTransform)
        {
            if (pooledObject == null)
                return null;

            if (pooledObjects == null)
            {
                InitializePool(poolCount, distanceBetweenObstacles, pooledObject, parentTransform);
            }

            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            randomIndex = Random.Range(0, pooledObject.Length);
            GameObject obj = UnityEngine.Object.Instantiate(pooledObjects[randomIndex], parentTransform);
            obj.transform.position = new Vector3(parentTransform.position.x, parentTransform.position.y, parentTransform.position.z + (randomIndex * distanceBetweenObstacles));
            pooledObjects.Add(obj);
            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public GameObject GetPooledGameObject(Transform transform)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }

            // Spawn Random Obstacle
            randomIndex = Random.Range(0, pooledObjects.Count);
            GameObject obj = UnityEngine.Object.Instantiate(pooledObjects[randomIndex], transform);
            pooledObjects.Add(obj);
            return obj;
        }

        #endregion
    }
}
