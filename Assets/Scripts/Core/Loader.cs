using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] float timeToReload = 2f;
    public static Loader instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        AudioPlayer.instance.PlayMusic(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        AudioPlayer.instance.PlayMusic(0);
    }

    public void ReloadScene()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        UIHandler.instance.WarningRoutine("Você tomou a pípula. É um ciclo sem fim");
        yield return new WaitForSecondsRealtime(timeToReload);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioPlayer.instance.PlayMusic(1);
    }
}
