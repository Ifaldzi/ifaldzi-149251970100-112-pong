using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int defaultSpeed;
    public Vector3 defaultScale;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;
    private int speed;

    private float longPUTime;
    private float speedPUTime;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = GetInput();

        MoveObject(movement);

        CountDownPowerUp(ref longPUTime, ResetPaddleLong);
        CountDownPowerUp(ref speedPUTime, ResetPaddleSpeed);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }

        if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Movement (" + this.name + "): " + movement);

        rig.velocity = movement;
    }

    public void Extend(float magnitude, float duration)
    {
        transform.localScale = new Vector3(defaultScale.x, defaultScale.y * magnitude, defaultScale.z);

        longPUTime += duration;
    }

    private void ResetPaddleLong()
    {
        transform.localScale = defaultScale;
    }

    public void SpeedUp(float magnitude, float duration)
    {
        speed = defaultSpeed * (int) magnitude;

        speedPUTime += duration;
    }

    private void ResetPaddleSpeed()
    {
        speed = defaultSpeed;
    }

    private void CountDownPowerUp(ref float powerUpTime, Action callback)
    {
        if (powerUpTime > 0)
        {
            powerUpTime -= Time.deltaTime;

            if (powerUpTime <= 0)
            {
                callback();
            }
        }
    }
}
