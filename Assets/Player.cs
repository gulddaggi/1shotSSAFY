using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody playerRb;
    Vector3 fireVector;

    public GameObject inputDegreeText;

    void Start()
    {
        fireVector = Vector3.right;
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.DrawLine(gameObject.transform.position, fireVector, Color.red);
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
