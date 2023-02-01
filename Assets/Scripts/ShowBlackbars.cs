using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShowBlackbars", menuName = "DialogueScriptEvents/ShowBlackBars", order = 1)]
public class ShowBlackbars : DialogueScriptEvent
{
  const float DEFAULT_TRANSITION_TIME = 1f;

  public float transitionTime = -1f;

  public override void Play(Action finishCallback)
  {
    //fade screen

    //bring in cinematic widescreen

    base.Play(finishCallback);
    //finishCallback?.Invoke();
  }
}
