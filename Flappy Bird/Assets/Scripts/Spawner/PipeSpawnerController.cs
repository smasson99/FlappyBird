using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PipeSpawnerController : MonoBehaviour
{
  private GameController gameController = null;
  private TimedSpawner timedSpawner;

  private void Awake()
  {
    this.gameController = GameObject.FindGameObjectWithTag(Tags.GameController).
    GetComponent<GameController>();
    timedSpawner = GetComponent<TimedSpawner>();

    if (gameController == null)
    {
      Debug.Log("GameController component or GameObject not found!");
    }
    if (timedSpawner == null)
    {
      Debug.Log("TimedSpawner component not found!");
    }

    UpdateTimedSpawner();
  }

  private void OnEnable()
  {
    gameController.OnGameStartedValueChanged += UpdateTimedSpawner;
  }

  private void OnDisable()
  {
    gameController.OnGameStartedValueChanged -= UpdateTimedSpawner;
  }

  private void UpdateTimedSpawner()
  {
    timedSpawner.enabled = gameController.IsGameStarted;
  }
}
