using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBall : Ball
{
    private LineRenderer line;
    private Vector3 startPosition;
    public Vector2 fireVelocity;
    public float power;
    Vector3 fireVector;
    Vector3 towordVector;
    public GameObject inputDegreeText;
    public GameObject inputPowerText;

    protected override void Start()
    {
        base.Start();

        line = GetComponent<LineRenderer>();
        line.sortingOrder = 3;
        line.positionCount = 2;
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;

        power = 10f;
    }

    protected override void Update()
    {
        base.Update();

        towordVector = new Vector3(gameObject.transform.position.x + fireVelocity.x, gameObject.transform.position.y + fireVelocity.y, -0.1f);
        line.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.1f));
        line.SetPosition(1, towordVector);
    }

    public void shot()
    {
        rb.velocity = fireVelocity * power;
    }

    public void SetDegree()
    {
        float degree = float.Parse(inputDegreeText.GetComponent<InputField>().text);
        fireVelocity = Quaternion.AngleAxis(degree, Vector3.forward).normalized * fireVelocity;
    }

    public void SetPower()
    {
        float power = float.Parse(inputPowerText.GetComponent<InputField>().text);
        this.power = power;
    }

    public override void InPocket()
    {
        base.InPocket();
        power = 10f;
        fireVelocity = new Vector2(1.0f, 0.0f);

        gameManager.Respawn(ballIdx);
    }
}
