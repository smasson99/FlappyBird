using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class ScrollController : MonoBehaviour
{
  private float sizeX;

  [Tooltip("The offsetX between each sprites when replaced.")]
  [SerializeField]
  private float offsetX = 4.5f;

  [Tooltip("The sprites game objects to scroll.")]
  [SerializeField]
  private List<GameObject> spriteGameObjects = null;
  private float startPosition;

  private int indexLast;

  private void Awake()
  {
    sizeX = spriteGameObjects[0].GetComponent<SpriteRenderer>().size.x;
    startPosition = sizeX * spriteGameObjects.Count / 2;
    indexLast = spriteGameObjects.Count - 1;
    if (offsetX == 0)
    {
      offsetX = sizeX;
    }

    if (spriteGameObjects == null || spriteGameObjects.Count == 0)
    {
      Debug.Log("No sprite found!");
    }
  }

  private void Update()
  {
    /*if (Input.GetKeyDown(KeyCode.G))
    {
      Debug.Log("GG");
      ReplaceSprite(1);
    }*/
    int index = GetIndexOutOfScreen();
    if (index >= 0)
    {
      ReplaceSprite(index);
    }
  }

  private void ReplaceSprite(int index)
  {
    /*spriteGameObjects[index].transform.localPosition = new Vector3(startPosition - offsetX + sizeX,
    0, transform.position.z);*/
    spriteGameObjects[index].transform.localPosition = new Vector3(spriteGameObjects[indexLast].transform.position.x +
    offsetX, 0, transform.position.z);
    indexLast = index;
  }
  
  private int GetIndexOutOfScreen()
  {
    for (int i = 0; i < spriteGameObjects.Count; ++i)
    {
      if (IsOutOfScreen(spriteGameObjects[i].transform.position.x))
      {
        return i;
      }
    }
    return -1;
  }

  private bool IsOutOfScreen(float positionX)
  {
    float outPositionX = startPosition - offsetX - sizeX * (spriteGameObjects.Count - 1);
    return positionX < outPositionX;
  }
}
