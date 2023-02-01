using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBubble : MonoBehaviour
{
  public Sprite bubbleSprite;

  void Start()
  {
    Debug.Log(string.Format("DEBUG: pivot settings = {0}, {1}", bubbleSprite.pivot.x, bubbleSprite.pivot.y));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
