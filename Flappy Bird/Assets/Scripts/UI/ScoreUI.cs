using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class ScoreUI : MonoBehaviour
{
  private GameController gameController = null;
  private Text scoreText = null;

  private const string FORMAT = "{0:00}";


  private void Awake()
  {
    gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();
    scoreText = GetComponent<Text>();

    if (gameController == null)
    {
      Debug.Log("GameController component not found!");
    }
    if (scoreText == null)
    {
      Debug.Log("Text for score not found!");
    }
  }

  private void Start()
  {
    UpdateScoreUI();
  }

  private void OnEnable()
  {
    gameController.OnScoreChanged += UpdateScoreUI;
  }

  private void OnDisable()
  {
    gameController.OnScoreChanged -= UpdateScoreUI;
  }

  private void UpdateScoreUI()
  {
    int? currentScore = gameController?.Score ?? 0;
    scoreText.text = string.Format(FORMAT, currentScore);
  }
}
