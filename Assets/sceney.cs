using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceney : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }
}
