using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] float speed = 5f;
    private float direction = 0f;
    private Rigidbody2D player;

    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float bounceSpeed;
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
           bounceSpeed = 500;
        }
      
    }

    public void MoveCharacter(float direction)
    {   
        player.velocity = new Vector2(direction * speed, player.velocity.y); 
    }

    public void StopCharacter()
    {   
        if (isOnGround)
        {
            player.velocity = Vector2.zero;
        }
    }
    
    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Bouncey" && isOnGround)
        {
              bounceSpeed += 250f;
              
              if(bounceSpeed >= 1000f)
              {
                
              }
              
              player.AddForce(new Vector2(0, bounceSpeed));
        }
    }
}
