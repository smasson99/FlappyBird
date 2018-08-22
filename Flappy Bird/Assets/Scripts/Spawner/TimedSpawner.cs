using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
  [Tooltip("The prefab to spawn repeatedly.")]
  [SerializeField]
  private GameObject prefab = null;

  [Tooltip("The time in seconds for each spawn.")]
  [SerializeField]
  private float spawnDelayInSeconds = 2.0f;

  private void Awake()
  {
    if (prefab == null)
    {
      Debug.Log("The prefab was not found!");
    }
  }

  private void OnEnable()
  {
    StartCoroutine(SpawnerCoroutine());
  }

  private void OnDisable()
  {
    StopAllCoroutines();
  }

  private IEnumerator SpawnerCoroutine()
  {
    while (true)
    {
      yield return new WaitForSeconds(spawnDelayInSeconds);
      SpawnPrefab();
    }
  }

  private void SpawnPrefab()
  {
    Instantiate(prefab, transform.position, Quaternion.identity);
  }
}
