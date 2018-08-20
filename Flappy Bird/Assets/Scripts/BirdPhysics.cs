using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPhysics : MonoBehaviour
{
  [SerializeField] private float flapForce = 1;

  private new Rigidbody2D rigidbody;

  private void Awake()
  {
    rigidbody = transform.root.gameObject.AddComponent<Rigidbody2D>();
  }

  public void Flap()
  {
    rigidbody.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
  }
}
