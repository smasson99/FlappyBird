using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public delegate void ScoreChangedEventHandler();
public delegate void GameStartedEventHandler();
public delegate void GameOverEventHandler();

public class GameController : MonoBehaviour
{
  [Tooltip("The keyword for the button to start or restard the game.")]
  [SerializeField]
  private string startRestartKey = "space";

  private MainController mainController = null;
  private PipePassedEventChannel pipePassedEventChannel;
  private PlayerDiedEventChannel playerDiedEventChannel;
  private int score;
  private bool isGameStarted;
  private bool isGameOver;

  public int Score 
  {
    get
    {
      return score;
    }
    set
    {
      score = value;
      NotifyScoreChanged();
    }
  }
  public bool IsGameStarted
  {
    get
    {
      return this.isGameStarted;
    }
    set
    {
      this.isGameStarted = value;
      NotifyGameStartedValueChanged();
    }
  }
  public bool IsGameOver
  {
    get
    {
      return this.isGameOver;
    }
    set
    {
      this.isGameOver = value;
      NotifyGameOverValueChanged();
    }
  }
  public event ScoreChangedEventHandler OnScoreChanged;
  public event GameStartedEventHandler OnGameStartedValueChanged;
  public event GameOverEventHandler OnGameOverValueChanged;

  private void Awake()
  {
    mainController = GameObject.FindGameObjectWithTag(Tags.MainController).
    GetComponent<MainController>();
    pipePassedEventChannel = GetComponent<PipePassedEventChannel>();
    playerDiedEventChannel = GetComponent<PlayerDiedEventChannel>();

    if (mainController == null)
    {
      Debug.Log("MainController GameObject or component not found!");
    }
    if (pipePassedEventChannel == null)
    {
      Debug.Log("PipePassedEventChannel component not found!");
    }
    if (playerDiedEventChannel == null)
    {
      Debug.Log("PlayerDiedEventChannel component not found!");
    }
  }

  private void Update()
  {
    if (!IsGameStarted)
    {
      if (Input.GetKeyDown(startRestartKey))
      {
        StartGame();
      }
    }
    else if (IsGameOver)
    {
      if (Input.GetKeyDown(startRestartKey))
      {
        RestartGame();
      }
    }
  }

  private void OnEnable()
  {
    pipePassedEventChannel.OnEventPublished += IncrementScore;
    playerDiedEventChannel.OnEventPublished += StopGame;
  }

  private void OnDisable()
  {
    pipePassedEventChannel.OnEventPublished -= IncrementScore;
  }

  private void IncrementScore()
  {
    Score++;
  }

  private void NotifyScoreChanged()
  {
    if (OnScoreChanged != null)
    {
      OnScoreChanged();
    }
  }

  private void NotifyGameOverValueChanged()
  {
    if (OnGameOverValueChanged != null)
    {
      OnGameOverValueChanged();
    }
  }

  private void NotifyGameStartedValueChanged()
  {
    if (OnGameStartedValueChanged != null)
    {
      OnGameStartedValueChanged();
    }
  }

  private void StartGame()
  {
    IsGameStarted = true;
  }

  private void StopGame()
  {
    Debug.Log("StopGame!");
    IsGameOver = true;
  }

  private void RestartGame()
  {
    mainController.RestartGame();
  }
}
