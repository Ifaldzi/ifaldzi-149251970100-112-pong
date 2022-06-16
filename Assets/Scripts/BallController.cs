using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;

    private Rigidbody2D rig;

    public Vector2 resetPosition;

    private GameObject lastPaddleHit;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        rig.velocity = speed;

        if (speed.x > 0)
        {
            lastPaddleHit = GameObject.Find("Paddle (left)");
        } else
        {
            lastPaddleHit = GameObject.Find("Paddle (right)");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetBall()
    {
        transform.position = resetPosition;
        rig.velocity = speed;
    }

    public void SpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public GameObject GetLastPaddleHit()
    {
        return lastPaddleHit;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lastPaddleHit = collision.gameObject;
        }
    }
}
