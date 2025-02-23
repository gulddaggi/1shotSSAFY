using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    protected Rigidbody2D playerRb;
    public Vector2 velocity;

    protected virtual void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        velocity = playerRb.velocity;
    }
}
