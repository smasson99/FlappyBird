using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
  [Tooltip("The TranslateMover component that must translate the object. If null, will simply get the component.")]
  [SerializeField]
  private TranslateMover translateMoverComponent = null;

  [Tooltip("The keyword of the key to flap")]
  [SerializeField]
  private string keyFlap = "space";

  [Tooltip("The BirdPhysics component.")]
  [SerializeField]
  private BirdPhysics birdPhysics = null;
  private CollisionSensor collisionSensor;

  private void Awake()
  {
    this.birdPhysics = birdPhysics ?? transform.root.GetComponentInChildren<BirdPhysics>();
    this.collisionSensor = transform.root.GetComponentInChildren<CollisionSensor>();

    if (birdPhysics == null)
    {
      SayToLog("BirdPhysics component not found!");
    }
    if (collisionSensor == null)
    {
      SayToLog("CollisionSensor component not found!");
    }
  }

  private void OnEnable()
  {
    this.collisionSensor.OnCollision += Die;
  }

  private void OnDisable()
  {
    this.collisionSensor.OnCollision -= Die;
  }

  private void Update()
  {
    if (Input.GetKeyDown(keyFlap))
      Flap();
  }

  private void SayToLog(string message)
  {
    Debug.Log(message);
  }

  private void Flap()
  {
    birdPhysics?.Flap();
  }

  private void Die()
  {
    Hide();
  }

  private void Hide()
  {
    transform.root.gameObject.SetActive(false);
  }
}
