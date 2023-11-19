using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncey : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundManager.PlaySound("bounce");
        }
    }
}