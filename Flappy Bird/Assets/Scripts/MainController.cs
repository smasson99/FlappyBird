using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class MainController : MonoBehaviour
{
  private static bool IsSceneLoaded(string name)
  {
    for (var i = 0; i < SceneManager.sceneCount; i++)
      if (SceneManager.GetSceneAt(i).name == name) return true;

    return false;
  }

  private static void LoadGame()
  {
    if (!IsSceneLoaded(Scenes.Game))
    {
      SceneManager.LoadSceneAsync(Scenes.Game, LoadSceneMode.Additive);
    }

    //La scène active est celle dans laquelle les GameObjects sont créés au runtime.
    SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.Game));
  }

  private void Start()
  {
    LoadGame();
  }
}
