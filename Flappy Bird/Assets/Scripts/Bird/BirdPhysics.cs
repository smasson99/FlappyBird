using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPhysics : MonoBehaviour
{
  [Tooltip("The force to apply to the rigidbody for each flaps.")]
  [SerializeField]
  private float flapForce = 5;
  //Le mot clé "new" confirme que nous voulons "shadow" la propriété "rigidbody" déjà existante dans "MonoBehaviour".
  private new Rigidbody2D rigidbody;

  private void Awake()
  {
    //Nous allons chercher la racine (root) et nous y ajoutons un "Rigidbody2D".
    rigidbody = transform.root.gameObject.AddComponent<Rigidbody2D>();
  }

  public void Flap()
  {
    rigidbody.velocity = Vector3.up * flapForce;
  }
}
