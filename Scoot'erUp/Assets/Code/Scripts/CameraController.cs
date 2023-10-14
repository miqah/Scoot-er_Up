using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 1f, -10f);
    // private float smoothTransition = 0.5f;
    // private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform player;
    
    void Update()
    {
        Vector3 position = player.position + offset;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
