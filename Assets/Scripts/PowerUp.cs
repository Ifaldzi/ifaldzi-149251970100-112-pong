using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    public Collider2D ball;

    public float maxSpawnTime;
    public float magnitude;

    public PowerUpManager manager;

    private float spawnTime;

    public abstract void ActivatePowerUp();

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= maxSpawnTime)
        {
            Debug.Log(name + " removed");
            manager.RemovePowerUp(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            Debug.Log("Collide with power up");
            ActivatePowerUp();
            manager.RemovePowerUp(gameObject);
        }
    }
}
