using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallConflict : MonoBehaviour
{
    (Vector2, Vector2) calculateBall2BallCollision(Vector2 v1, Vector2 v2, Vector2 c1, Vector2 c2, float e = 1.0f)
    {
        // ±‚¡ÿ √‡
        Vector2 basicsX = (c2 - c1).normalized;
        Vector2 basicsY = Vector2.Perpendicular(basicsX);
        float sin1, sin2, cos1, cos2;

        if (v1.magnitude < 0.0001f)
        {
            sin1 = 0f;
            cos1 = 1f;
        }
        else
        {
            cos1 = Vector2.Dot(v1, basicsX) / v1.magnitude;
            Vector3 cross = Vector3.Cross(v1, basicsX);
            if (cross.z > 0)
            {
                sin1 = cross.magnitude / v1.magnitude;
            }
            else
            {
                sin1 = -cross.magnitude / v1.magnitude;
            }
        }

        if (v2.magnitude < 0.0001f)
        {
            sin2 = 0f;
            cos2 = 1f;
        }
        else
        {
            cos2 = Vector2.Dot(v2, basicsX) / v2.magnitude;
            Vector3 cross = Vector3.Cross(v2, basicsX);
            if (cross.z > 0)
            {
                sin2 = cross.magnitude / v2.magnitude;
            }
            else
            {
                sin2 = -cross.magnitude / v2.magnitude;
            }
        }

        Vector2 u1, u2;
        u1 = ((1 - e) * v1.magnitude * cos1 + (1 + e) * v2.magnitude * cos2) / 2 * basicsX - v1.magnitude * sin1 * basicsY;
        u2 = ((1 + e) * v1.magnitude * cos1 + (1 - e) * v2.magnitude * cos2) / 2 * basicsX - v2.magnitude * sin2 * basicsY;

        return (u1, u2);
    }

    (Vector2, Vector2) calculateBall2BallCollisionSimple(Vector2 v1, Vector2 v2)
    {
        return (v2, v1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D crashedBallRb = gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D crashingBallPlayerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 v1 = gameObject.GetComponent<Ball>().velocity;
            Vector2 v2 = collision.gameObject.GetComponent<Ball>().velocity;

            (crashedBallRb.velocity, crashingBallPlayerRb.velocity) = calculateBall2BallCollision(v1, v2, crashedBallRb.position, crashingBallPlayerRb.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
