using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class DeathScreenUI : MonoBehaviour
{
  private GameController gameController = null;

  private void Awake()
  {
    this.gameController = GameObject.FindGameObjectWithTag(Tags.GameController).
    GetComponent<GameController>();

    if (gameController == null)
    {
      Debug.Log("GameController component not found!");
    }

    gameController.OnGameOverValueChanged += UpdateUI;

    UpdateUI();
  }

  private void OnDestroy()
  {
    gameController.OnGameOverValueChanged -= UpdateUI;
  }

  private void UpdateUI()
  {
    gameObject.SetActive(gameController.IsGameOver);
  }
}
