using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddle : PowerUp
{
    public float duration;

    override public void ActivatePowerUp()
    {
        BallController ballScript = ball.GetComponent<BallController>();
        PaddleController paddle = ballScript.GetLastPaddleHit().GetComponent<PaddleController>();

        paddle.Extend(magnitude, duration);
    }
}
