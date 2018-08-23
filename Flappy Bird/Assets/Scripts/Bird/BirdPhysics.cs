using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class BirdPhysics : MonoBehaviour
{
  [Tooltip("The force to apply to the rigidbody for each flaps.")]
  [SerializeField]
  private float flapForce = 5;
  //Le mot clé "new" confirme que nous voulons "shadow" la propriété "rigidbody" déjà existante dans "MonoBehaviour".
  private new Rigidbody2D rigidbody = null;

  [Tooltip("The flap line while in MainMenu.")]
  [SerializeField]
  private float flapLine = 0;

  private GameController gameController;

  private void Awake()
  {
    //Nous allons chercher la racine (root) et nous y ajoutons un "Rigidbody2D".
    rigidbody = transform.root.gameObject.AddComponent<Rigidbody2D>();
    gameController = GameObject.FindWithTag(Tags.GameController)
                                   .GetComponent<GameController>();
    if (gameController == null)
    {
      Debug.Log("GameController component or GameObject not found!");
    }
    if (rigidbody == null)
    {
      Debug.Log("Error while creating the rigidbody!");
    }
  }

  private void Update()
  {
    if (!gameController.IsGameStarted && transform.root.position.y < flapLine)
    {
      Flap();
    }
  }

  public void Flap()
  {
    rigidbody.velocity = Vector3.up * flapForce;
  }
}
