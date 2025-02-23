using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] balls = new GameObject[5];
    public Vector2[] initialPosition = new Vector2[5];

    public GameObject playerPos;
    public GameObject targetPos;

    void Start()
    {
        for (int i = 0; i < initialPosition.Length; i++)
        {
            if (balls[i] != null)
            {
                initialPosition[i] = balls[i].transform.position;
            }
        }

        Debug.Log(Vector2.Distance(balls[0].transform.position, balls[1].transform.position));
        Mathf.Atan()
    }

    void Update()
    {
        playerPos.GetComponent<Text>().text = "Player x : " + Mathf.Round(balls[0].transform.position.x*10)*0.1f + " , y : " + Mathf.Round(balls[0].transform.position.y*10)*0.1f;
        targetPos.GetComponent<Text>().text = "Target x : " + Mathf.Round(balls[1].transform.position.x*10)*0.1f + " , y : " + Mathf.Round(balls[1].transform.position.y*10)*0.1f;
    }

    public void Respawn(int idx)
    {
        balls[idx].transform.position = initialPosition[idx];

        StartCoroutine(PlayerRespawnCoroutine(idx));
    }

    IEnumerator PlayerRespawnCoroutine(int idx)
    {
        yield return new WaitForSeconds(1.5f);

        balls[idx].gameObject.SetActive(true);
    }
}
