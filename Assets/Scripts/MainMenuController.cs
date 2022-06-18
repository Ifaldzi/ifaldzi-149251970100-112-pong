using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Created by Ifaldzi - 149251970100-112");

        SceneManager.LoadScene(1);
    }

    public void OpenAuthor()
    {
        Debug.Log("Created by ifaldzi");
    }

    public void OpenCredit()
    {
        SceneManager.LoadScene("Credit Scene");
    }
}
