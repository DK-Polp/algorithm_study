using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
