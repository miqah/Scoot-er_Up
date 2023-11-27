using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public Transform positionOne;
    public Transform positionTwo;
    private Transform currentTarget;
    public int startingPoint;

    void Start()
    {
        currentTarget = startingPoint == 0 ? positionOne : positionTwo;
        transform.position = currentTarget.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, currentTarget.position) <= 0.001f)
        {
            currentTarget = (currentTarget == positionOne) ? positionTwo : positionOne;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}






