using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
  private Vector2 startPosition;
  private Rigidbody2D cupRigidbody;
  
  [SerializeField] float groundRadius;
  [SerializeField] float maxForce;
  [SerializeField] Transform ground;
  [SerializeField] LayerMask groundLayer;
  
  [SerializeField] Transform cup;
  private bool isThrowing;
  private bool canKick;
  public float throwForce = 5f;
  private bool isTouchingGround;
  private bool isNotMoving;
  //public float notMovingThreshold = 0.1f;

  private void Start()
  {
    cupRigidbody = GetComponent<Rigidbody2D>();
  }

  private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(ground.position, groundRadius, groundLayer);

        if (Input.GetMouseButtonDown(0) && isTouchingGround)
        {
            startPosition = Input.mousePosition;
            canKick = true;
        }

        if (Input.GetMouseButtonUp(0) && canKick)
        {
            Vector2 endPosition = Input.mousePosition;
            Vector2 throwDirection = (endPosition - startPosition).normalized;
            float dragDistance = Vector2.Distance(startPosition, endPosition);
            float forceMagnitude = dragDistance * throwForce;

            if (forceMagnitude > maxForce)
            {
                forceMagnitude = maxForce;
            }

            cupRigidbody.AddForce(throwDirection * forceMagnitude, ForceMode2D.Impulse);
            canKick = false;
        }
    }
}
