using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    Rigidbody2D playerRb;
    public Vector2 fireVelocity = new Vector2(10.0f, 10.0f);
    public Vector2 velocity;
    public float power;
    Vector3 fireVector;
    Vector3 towordVector;

    public GameObject inputDegreeText;

    void Start()
    {
        // fireVector = Vector3.right;
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.velocity = fireVelocity * power;
        power = 10f;
    }

    void Update()
    {
        velocity = playerRb.velocity;

        towordVector = new Vector3(gameObject.transform.position.x + fireVelocity.x, gameObject.transform.position.y + fireVelocity.y, 0f);

        Debug.DrawLine(gameObject.transform.position, towordVector, Color.red);
    }

    public void shot()
    {
        playerRb.velocity = fireVelocity * power;
    }

    public void rotate()
    {
        Debug.Log(inputDegreeText.GetComponent<InputField>().text);
        int degree = int.Parse(inputDegreeText.GetComponent<InputField>().text);

        fireVector = Quaternion.AngleAxis(degree, Vector3.up).normalized * fireVector;
    }
}
