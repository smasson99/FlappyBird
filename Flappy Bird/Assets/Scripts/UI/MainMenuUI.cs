using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class MainMenuUI : MonoBehaviour
{
  private GameController gameController;

  private void Awake()
  {
    gameController = GameObject.FindWithTag(Tags.GameController)
                               .GetComponent<GameController>();

    gameController.OnGameStartedValueChanged += UpdateUI;

    UpdateUI();
  }

  private void OnDestroy()
  {
    gameController.OnGameStartedValueChanged -= UpdateUI;
  }

  private void UpdateUI()
  {
    gameObject.SetActive(!gameController.IsGameStarted);
  }
}
