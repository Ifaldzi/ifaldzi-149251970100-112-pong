using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public Vector3 defaultScale;

    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    private float longPUTime;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = GetInput();

        MoveObject(movement);

        CountDownPowerUp(ref longPUTime, ResetPaddleLong);
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
        //Debug.Log("Movement (" + this.name + "): " + movement);

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
