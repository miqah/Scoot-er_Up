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
    } 

    void OnMouseUp()
    {
        lineRenderer.enabled = false;
        if (isTouchingGround)
        {
            float distance = Vector3.Distance(initialMousePosition, Input.mousePosition);
            float normalizedDistance = Mathf.Clamp01(distance / 100f); // Adjust as needed
            float calculatedThrowStrength = Mathf.Lerp(minThrowStrength, maxThrowStrength, normalizedDistance);
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

        Vector3 lineEndPosition = throwV.normalized * lineLength;

        lineRenderer.SetPosition(1, lineEndPosition);
        lineRenderer.enabled = true;
    }
}