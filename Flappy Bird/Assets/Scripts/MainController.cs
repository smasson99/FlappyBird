using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class MainController : MonoBehaviour
{

  private void Start()
  {
    StartCoroutine(LoadGame());
  }

  private static bool IsSceneLoaded(string name)
  {
    for (var i = 0; i < SceneManager.sceneCount; i++)
      if (SceneManager.GetSceneAt(i).name == name) return true;

    return false;
  }

  public static IEnumerator LoadGame()
  {
    if (!IsSceneLoaded(Scenes.Game))
    {
      yield return SceneManager.LoadSceneAsync(Scenes.Game, LoadSceneMode.Additive);
    }
    
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.Game));
  }

  public static IEnumerator UnloadGame()
  {
    if (IsSceneLoaded(Scenes.Game))
    {
      yield return SceneManager.UnloadSceneAsync(Scenes.Game);
    }
  }

  public static IEnumerator ReloadGame()
  {
    yield return UnloadGame();
    yield return LoadGame();
  }

  public void RestartGame()
  {
    StartCoroutine(ReloadGame());
  }
}
