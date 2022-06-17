using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddle : PowerUp
{
    public float duration;

    public override void ActivatePowerUp()
    {
        PaddleController paddle = ball
            .GetComponent<BallController>()
            .GetLastPaddleHit()
            .GetComponent<PaddleController>();

        paddle.SpeedUp(magnitude, duration);
    }
}
