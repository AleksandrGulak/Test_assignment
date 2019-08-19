using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogueScript : MonoBehaviour
{
    public DialogueBase[] Dialogue;
    public int DialogueToLoadOnStartIndex;
    public bool LoadOnStart;
    public bool DebugStart;


    private int dialogueToTriggerIndex;


    private void Start()
    {
        if (LoadOnStart)
        {
            TriggerDialogue(DialogueToLoadOnStartIndex);
        }
    }

    private void Update()
    {
        if (!LoadOnStart && DebugStart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TriggerDialogue(dialogueToTriggerIndex);
            }
        }       
    }

    public void TriggerDialogue(int dialogueIndx)
    {
        DialogueManager.instanceOfDialogueManager.EnqueueDialogue(Dialogue[dialogueIndx]);
    }
}
