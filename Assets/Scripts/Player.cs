using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRb;
    public Vector2 startVelocity = new Vector2(10.0f, 10.0f);
    public Vector2 velocity;
    Vector3 fireVector;

    public GameObject inputDegreeText;

    void Start()
    {
        // fireVector = Vector3.right;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.velocity = startVelocity;
    }

    void Update()
    {
        velocity = playerRb.velocity;
        // Debug.DrawLine(gameObject.transform.position, fireVector, Color.red);
    }

    public void shot()
    {
        playerRb.AddForce(fireVector * 400.0f);
    }

    public void rotate()
    {
        Debug.Log(inputDegreeText.GetComponent<InputField>().text);
        int degree = int.Parse(inputDegreeText.GetComponent<InputField>().text);

        fireVector = Quaternion.AngleAxis(degree, Vector3.up).normalized * fireVector;
    }
}
