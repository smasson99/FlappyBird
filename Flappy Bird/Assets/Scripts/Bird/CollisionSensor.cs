using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollisionSensorEventHandler();

public class CollisionSensor : MonoBehaviour
{
  public event CollisionSensorEventHandler OnCollision;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    NotifyCollisionSensed();
  }

  private void NotifyCollisionSensed()
  {
    if (OnCollision != null)
      OnCollision();
  }
}
