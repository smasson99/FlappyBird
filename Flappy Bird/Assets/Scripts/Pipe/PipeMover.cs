using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
  [Tooltip("The speed to continiously move the pipe in the left direction.")]
  [SerializeField]
  private float speed = 1.0f;
  
  void Update()
  {
    Move(Vector3.left, this.speed);
  }

  private void Move(Vector3 direction, float speed)
  {
    transform.root.Translate(direction * speed * Time.deltaTime);
  }
}
