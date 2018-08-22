using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [Tooltip("The TranslateMover component that must translate the object. If null, will simply get the component.")]
  [SerializeField]
  private TranslateMover translateMoverComponent = null;

  [Tooltip("The keyword of the key to go up")]
  [SerializeField]
  private string keyUp = "w";

  [Tooltip("The keyword of the key to go up")]
  [SerializeField]
  private string keyLeft = "a";

  [Tooltip("The keyword of the key to go up")]
  [SerializeField]
  private string keyDown = "s";

  [Tooltip("The keyword of the key to go up")]
  [SerializeField]
  private string keyRight = "d";

  private void Awake()
  {
    //Si le component n'est pas null, il reste comme il était, sinon on recherche le component
    this.translateMoverComponent = translateMoverComponent ?? GetComponent<TranslateMover>();
    
    if (translateMoverComponent == null)
    {
      SayToLog("TranslateMover component not found!");
    }
  }

  private void Update()
  {
    if (Input.GetKey(keyUp))
      translateMoverComponent?.Move(Vector3.up);
    if (Input.GetKey(keyLeft))
      translateMoverComponent?.Move(Vector3.left);
    if (Input.GetKey(keyDown))
      translateMoverComponent?.Move(Vector3.down);
    if (Input.GetKey(keyRight))
      translateMoverComponent?.Move(Vector3.right);
  }

  private void SayToLog(string message)
  {
    Debug.Log(message);
  }
}
