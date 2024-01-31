using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public string sceneName;
    [SerializeField]
    private Animator transition;
    private float transitionTime = 1f;


    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        StartCoroutine(LoadLevel(sceneName));

    }

    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);

    }
}
