using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float _timeToReload = 2f;
    public static SceneLoader Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        AudioPlayer.Instance.PlayMusic(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        AudioPlayer.Instance.PlayMusic(0);
    }

    public void ReloadScene()
    {
        StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        UIHandler.Instance.WarningRoutine("Você tomou a pípula. É um ciclo sem fim");
        yield return new WaitForSecondsRealtime(_timeToReload);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioPlayer.Instance.PlayMusic(1);
    }
}
