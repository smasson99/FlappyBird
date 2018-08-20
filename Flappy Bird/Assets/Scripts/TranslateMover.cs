using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMover : MonoBehaviour
{
  [Tooltip("The speed to translate the transform.")]
  [SerializeField]
  private float speed = 1.0f;
  public float Speed
  {
    get
    {
      return this.speed;
    }
    private set
    {
      this.speed = value;
    }
  }

  public void Move(Vector3 direction)
  {
    transform.Translate(direction * speed * Time.deltaTime);
  }

  public void Move(Vector3 direction, float specificSpeed)
  {
    transform.Translate(direction * specificSpeed * Time.deltaTime);
  }
}
