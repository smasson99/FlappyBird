using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
  [Tooltip("The min pox in y of the pipe.")]
  [SerializeField]
  private float minY = -1.0f;
  [Tooltip("The max pox in y of the pipe.")]
  [SerializeField]
  private float maxY = 1.0f;

  [Tooltip("The GameObject of the upper pipe.")]
  [SerializeField]
  private GameObject upperPipe = null;
  [Tooltip("The GameObject of the lower pipe.")]
  [SerializeField]
  private GameObject lowerPipe = null;

  [Tooltip("The min pox in x of the pipe.")]
  [SerializeField]
  private float minX = 2.0f;
  [Tooltip("The max pox in x of the pipe.")]
  [SerializeField]
  private float maxX = 3.0f;

  private BirdSensor birdSensor;

  private void Awake()
  {
    birdSensor = transform.root.GetComponentInChildren<BirdSensor>();

    if (upperPipe == null)
    {
      Debug.Log("Could not find the upper pipe!");
    }
    if (lowerPipe == null)
    {
      Debug.Log("Could not find the lower pipe!");
    }
    if (birdSensor == null)
    {
      Debug.Log("Could not find the birdSensor component!");
    }

    RandomizePipeHeights();
    RandomizePipeWidths(upperPipe);
    RandomizePipeWidths(lowerPipe);
  }

  private void RandomizePipeHeights()
  {
    var height = Random.Range(minY, maxY);
    transform.root.Translate(Vector3.up * height);
  }

  private void OnEnable()
  {
    birdSensor.OnBirdSensed += NotifyBirdPassed;
  }

  private void OnDisable()
  {
    birdSensor.OnBirdSensed -= NotifyBirdPassed;
  }

  private void NotifyBirdPassed()
  {
    Debug.Log("Bird passed!");
  }

  private void RandomizePipeWidths(GameObject pipeToMove)
  {
    var width = Random.Range(minX, maxX);
    if (Random.Range(0, 2) > 1)
    {
      pipeToMove?.transform?.Translate(Vector3.left * width);
    }
    else
    {
      pipeToMove?.transform?.Translate(Vector3.right * width);
    }
  }
}
