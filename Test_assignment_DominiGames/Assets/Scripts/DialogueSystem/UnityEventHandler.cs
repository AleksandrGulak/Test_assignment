using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class UnityEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent EventHandler;
    public DialogueBase MyDialogue;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        EventHandler.Invoke();
        DialogueManager.instanceOfDialogueManager.CloseOptions();

        if(MyDialogue != null)
        {
            DialogueManager.instanceOfDialogueManager.EnqueueDialogue(MyDialogue);
        }
    }
}
