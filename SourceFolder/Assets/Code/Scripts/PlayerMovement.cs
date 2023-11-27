using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    private float direction = 0f;
    private Rigidbody2D player;

    [SerializeField]
    float groundRadius;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float bounceSpeed;
    private bool isOnGround;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(transform.position, groundRadius, groundLayer);
        
        if (isOnGround)
        {
            bounceSpeed = 0;
        }
    }

    public void StopCharacter()
    {
        Debug.Log("StopCharacter called");
        if (isOnGround)
        {
            Debug.Log("StopCharacter called");
            player.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Bouncey")
        {
            bounceSpeed += 500f;

            if (bounceSpeed >= 1500f)
            {
                bounceSpeed = 1500f;
            }

            player.AddForce(new Vector2(0, bounceSpeed));
        }
    }
}
