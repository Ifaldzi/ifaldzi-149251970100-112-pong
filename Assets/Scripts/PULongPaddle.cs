using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddle : PowerUp
{
    public float magnitude;
    public float duration;

    override public void ActivatePowerUp()
    {
        Debug.Log("Long paddle activated");

        BallController ballScript = ball.GetComponent<BallController>();
        PaddleController paddle = ballScript.GetLastPaddleHit().GetComponent<PaddleController>();

        Debug.Log(paddle);
        paddle.Extend(magnitude, duration);
    }
}
