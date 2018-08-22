using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public delegate void ScoreChangedEventHandler();

public class GameController : MonoBehaviour
{
  private PipePassedEventChannel pipePassedEventChannel;
  public event ScoreChangedEventHandler OnScoreChanged;

  private int score;
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

  private void Awake()
  {
    pipePassedEventChannel = GetComponent<PipePassedEventChannel>();

    if (pipePassedEventChannel == null)
    {
      Debug.Log("The PipePassedEventChannel component was not found!");
    }
  }

  private void OnEnable()
  {
    pipePassedEventChannel.OnEventPublished += IncrementScore;
  }

  private void OnDisable()
  {
    pipePassedEventChannel.OnEventPublished -= IncrementScore;
  }

  private void IncrementScore()
  {
    ++Score;
  }

  private void NotifyScoreChanged()
  {
    if (OnScoreChanged != null)
    {
      OnScoreChanged();
    }
  }
}
