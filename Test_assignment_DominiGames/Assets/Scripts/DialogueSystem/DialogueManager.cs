using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instanceOfDialogueManager;
    private void Awake()
    {
        if(instanceOfDialogueManager != null)
        {
            Debug.LogWarning("ERROR (No dialogue manager)" + gameObject.name);
        }
        else
        {
            instanceOfDialogueManager = this;
        }
    }

    public GameObject DialogueBox;

    public TMP_Text DialogueName;
    public TMP_Text DialogueText;
    public float TypeDelay = 0.001f;
    public Image DialoguePortrait;

    public GameObject DialogueOptionUI;
    public TMP_Text QuestionText;
    public GameObject[] OptionButtons;
    public Queue<DialogueBase.Info> DialogueInfo = new Queue<DialogueBase.Info>();

    private bool isDialogueOption;
    private bool stillTyping;
    private int optionsAmount;

    public void EnqueueDialogue(DialogueBase db)
    {
        if (stillTyping)
        {
            return;
        }
        else
        {
            stillTyping = true;
        }
        DialogueBox.SetActive(true);
        DialogueInfo.Clear();

        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.OptionsInfo.Length;
            QuestionText.text = dialogueOptions.QuestionText;
            for(int i = 0; i < OptionButtons.Length; i++)
            {
                OptionButtons[i].SetActive(false);
            }
            for (int i = 0; i < optionsAmount; i++)
            {
                OptionButtons[i].SetActive(true);
                OptionButtons[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = dialogueOptions.OptionsInfo[i].ButtonName;
                UnityEventHandler myEventHandler = OptionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.EventHandler = dialogueOptions.OptionsInfo[i].MyEvent;
                if(dialogueOptions.OptionsInfo[i].nextDialogue != null)
                {
                    myEventHandler.MyDialogue = dialogueOptions.OptionsInfo[i].nextDialogue;
                }
                else
                {
                    myEventHandler.MyDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }

        foreach(DialogueBase.Info info in db.DialogueInfo)
        {
            DialogueInfo.Enqueue(info);
        }
        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if(DialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        DialogueBase.Info info = DialogueInfo.Dequeue();

        DialogueName.text = info.MyName;
        DialogueText.text = info.MyText;
        DialoguePortrait.sprite = info.Portrait;

        //StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        DialogueText.text = "";
        foreach(char c in info.MyText.ToCharArray())
        {
            yield return new WaitForSeconds(TypeDelay);
            DialogueText.text += c;
            yield return null;
        }
    }

    public void EndOfDialogue()
    {
        DialogueBox.SetActive(false);
        stillTyping = false;
        OptionsLogic();
    }

    private void OptionsLogic()
    {
        if (isDialogueOption == true)
        {
            DialogueOptionUI.SetActive(true);
        }
    }

    public void CloseOptions()
    {
        DialogueOptionUI.SetActive(false);
    }
}
