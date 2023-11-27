// using UnityEngine;

// public class Ball : MonoBehaviour
// {
//     [SerializeField]
//     private float pushForce = 10f;

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Vector2 pushDirection = (other.transform.position - transform.position).normalized;
//             other
//                 .GetComponent<Rigidbody2D>()
//                 .AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

//             gameObject.SetActive(false);
//         }

//         if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
//         {
//             gameObject.SetActive(false);
//         }
//     }
// }
