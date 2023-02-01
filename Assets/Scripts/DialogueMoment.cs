using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//instantiate canvas for dialogue moment

//for scriptable objects, run through in order

//screen tap to proceed when at a stopping point

//when no more objects in queue, close dialogue moment and cleanup

public class DialogueMoment : MonoBehaviour
{
  private const float DEFAULT_TRANSITION_OUT = 1f;

  public DialogueScriptChain dialogueScriptChain;
  /// <summary>
  /// duration it takes for the dialogue moment to alpha out when using fade out. -1 uses default transition time
  /// </summary>
  public float transitionOutTime = -1f;
  public bool playOnStart = false;

  public GameObject dialogueCanvasPrefab;
  
  [SerializeField] //for debugging
  private DialogueScriptEvent currentScriptEvent;

  private GameObject instantiatedCanvas;
  private CanvasGroup defaultFadeOut;

  private bool initialized = false;
  private int scriptEventIterator = -1;

  private void Start()
  {
    if (playOnStart)
      PlayDialogueMoment();
  }

  private void Initialize()
  {
    scriptEventIterator = -1;
    instantiatedCanvas = Instantiate(dialogueCanvasPrefab);
    defaultFadeOut = instantiatedCanvas.GetComponent<CanvasGroup>();
    defaultFadeOut.alpha = 1;
    initialized = true;
  }

  public void PlayDialogueMoment()
  {
    if (initialized == false)
      Initialize();

    if (scriptEventIterator != -1)
    {
      Debug.LogError("ERROR: dialogue moment already playing!");
      return;
    }

    if (dialogueScriptChain == null || dialogueScriptChain.scriptEventChain.Length == 0)
    {
      Debug.LogError("ERROR: invalid dialogue script chain!");
      return;
    }

    scriptEventIterator = 0;
    currentScriptEvent = dialogueScriptChain.scriptEventChain[scriptEventIterator];
    currentScriptEvent.Play(Proceed);
  }

  private void Proceed()
  {
    scriptEventIterator++;

    if(scriptEventIterator >= dialogueScriptChain.scriptEventChain.Length)
    {
      StartCoroutine(CleanupDialogueMoment());
      return;
    }

    currentScriptEvent = dialogueScriptChain.scriptEventChain[scriptEventIterator];
    currentScriptEvent.Play(Proceed);
  }

  private IEnumerator CleanupDialogueMoment()
  {
    float t = 0;
    float transitionTime = transitionOutTime == -1 ? DEFAULT_TRANSITION_OUT : transitionOutTime;
    
    while(t < transitionOutTime)
    {
      defaultFadeOut.alpha = Mathf.Lerp(1, 0, t / transitionTime);
      yield return null;
      t += Time.deltaTime;
    }

    defaultFadeOut.alpha = 0;
    scriptEventIterator = -1;
    currentScriptEvent = null;
  }
}
