using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;

    public float maxSpawnTime;

    public PowerUpManager manager;

    private float spawnTime;

    private void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= maxSpawnTime)
        {
            manager.RemovePowerUp(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            ball.GetComponent<BallController>().SpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
}
