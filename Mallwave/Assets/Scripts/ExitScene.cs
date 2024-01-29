using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter2D(Collider2D player)
    {
        SceneManager.LoadScene(sceneName);
    }
}
