using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text leftScore;
    public Text rightScore;

    public ScoreManager scoreManager;

    public void Start()
    {
        
    }

    public void Update()
    {
        leftScore.text = scoreManager.leftScore.ToString();
        rightScore.text = scoreManager.rightScore.ToString();
    }
}
