using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    Vector3 throwV;
    Vector3 initialMousePosition; 
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float minThrowStrength = 10f; 
    [SerializeField] float maxThrowStrength = 600f; 
    [SerializeField] float groundRadius;
    [SerializeField] LayerMask groundLayer;
    private Vector3 initialObjectPosition;
    [SerializeField] float minLineLength = 0.05f; 
    [SerializeField] float maxLineLength = 1f;
    
    bool isTouchingGround = true;

    void OnMouseDown()
    {
        initialMousePosition = Input.mousePosition;
        initialObjectPosition = transform.position; 
        CalculateThrowVector();
        SetLineRenderer();
    }

    void OnMouseDrag()
    {
        Vector3 currentMousePosition = Input.mousePosition;
        Vector2 distance = Camera.main.ScreenToWorldPoint(currentMousePosition) - initialObjectPosition;
        
        throwV = -distance.normalized;
        
         
        CalculateThrowVector(); 
        SetLineRenderer();

        
        if (throwV.x < 0)
        {
            transform.localScale = new Vector3(-0.666f, 0.666f, 1);
        }
        else if (throwV.x > 0)
        {
            transform.localScale = new Vector3(0.666f, 0.666f, 1);
        }
      
    } 

    void OnMouseUp()
    {
        lineRenderer.enabled = false;
        
        if (isTouchingGround)
        {
            float distance = Vector3.Distance(initialMousePosition, Input.mousePosition);
            float normalizedDistance = Mathf.Clamp01(distance / 100f); 
            float calculatedThrowStrength = Mathf.Lerp(minThrowStrength, maxThrowStrength, normalizedDistance);

            if (throwV.x < 0)
            {
                transform.localScale = new Vector3(-.666f, .666f, 1);
            }
            else if (throwV.x > 0)
            {
                transform.localScale = new Vector3(.666f, .666f, 1);
            }

            rigidBody.AddForce(throwV * calculatedThrowStrength);
        }
    }

    void CalculateThrowVector()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance = mousePosition - this.transform.position;
        throwV = -distance.normalized;

        isTouchingGround = Physics2D.OverlapCircle(transform.position, groundRadius, groundLayer);
    }

    void SetLineRenderer()
    { 
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector3.zero);

        float distance = Vector3.Distance(initialMousePosition, Input.mousePosition);
        float normalizedDistance = Mathf.Clamp01(distance / 100f); 
        float lineLength = Mathf.Lerp(minLineLength, maxLineLength, normalizedDistance);
        
        if (transform.localScale.x < 0)
        { 
          Vector3 lineEndPosition = throwV.normalized * lineLength;
        
            lineEndPosition.x = -lineEndPosition.x;
            lineRenderer.SetPosition(1, lineEndPosition);
      }
        else
        {
            Vector3 lineEndPosition = throwV.normalized * lineLength;
            lineRenderer.SetPosition(1, lineEndPosition);
        }
        lineRenderer.material.color = CalculateLineColor(lineLength);
        lineRenderer.enabled = true;
    }

Color CalculateLineColor(float lineLength)
{
    if (lineLength >= maxLineLength)
    {
        return Color.red;
    }
    else if (lineLength >= maxLineLength * 0.5f)
    {
        return Color.green;
    }
    else
    {
        return Color.yellow;
    }
}
}