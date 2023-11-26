// using System.Collections.Generic;
// using UnityEngine;

// public class ProjectileThrower : MonoBehaviour
// {
//     public GameObject projectilePrefab;

//     [SerializeField]
//     private float speed = 5f;

//     private List<GameObject> projectilePool;
//     private int poolMax = 50;

//     private void Start()
//     {
//         InitializePool();
//     }

//     private void InitializePool()
//     {
//         projectilePool = new List<GameObject>();

//         for (int i = 0; i < poolMax; i++)
//         {
//             GameObject projectile = Instantiate(
//                 projectilePrefab,
//                 transform.position,
//                 Quaternion.identity
//             );
//             projectile.SetActive(false);
//             projectilePool.Add(projectile);
//         }
//     }

//     public void Throw(Vector3 targetPosition)
//     {
//         GameObject projectile = GetProjectileFromPool();

//         if (projectile != null)
//         {
//             Debug.Log("Projectile obtained from the pool.");

//             projectile.transform.position = transform.position;
//             projectile.SetActive(true);

//             Vector3 direction = (targetPosition - transform.position).normalized;
//             Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
//             projectileRB.velocity = direction * speed;
//         }
//         else
//         {
//             Debug.Log("No projectile available in the pool.");
//         }
//     }

//     private GameObject GetProjectileFromPool()
//     {
//         for (int i = 0; i < projectilePool.Count; i++)
//         {
//             if (!projectilePool[i].activeInHierarchy)
//             {
//                 return projectilePool[i];
//             }
//         }

//         GameObject newProjectile = Instantiate(
//             projectilePrefab,
//             transform.position,
//             Quaternion.identity
//         );
//         newProjectile.SetActive(false);
//         projectilePool.Add(newProjectile);
//         return newProjectile;
//     }
// }
