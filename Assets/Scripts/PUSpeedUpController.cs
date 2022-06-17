using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : PowerUp
{
    public override void ActivatePowerUp()
    {
        ball.GetComponent<BallController>().SpeedUp(magnitude);
    }
}
