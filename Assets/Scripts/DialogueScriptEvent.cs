using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScriptEvent : ScriptableObject
{
  public virtual void Play(Action finishCallback)
  {
    finishCallback?.Invoke();
  }
}
