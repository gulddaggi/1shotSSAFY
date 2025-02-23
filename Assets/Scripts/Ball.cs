using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public int ballIdx;
    protected Rigidbody2D rb;
    public Vector2 velocity;
    public GameManager gameManager;

    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        velocity = rb.velocity;
    }

    public virtual void InPocket()
    {
        gameObject.SetActive(false);
        rb.velocity = Vector2.zero;
    }
}
