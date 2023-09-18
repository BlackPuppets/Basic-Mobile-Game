using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadNewScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
