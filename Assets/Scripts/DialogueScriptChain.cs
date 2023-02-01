using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueMoment", menuName = "ScriptableObjects/DialogueMoment", order = 1)]
public class DialogueScriptChain : ScriptableObject
{
  [SerializeField]
  public DialogueScriptEvent[] scriptEventChain;
}
