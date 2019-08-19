using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "DialoguesOptions")]
public class DialogueOptions : DialogueBase
{
    [TextArea(2,10)]
    public string QuestionText;

    [System.Serializable]
    public class Options 
    {
        public string ButtonName;
        public DialogueBase nextDialogue;
        public UnityEvent MyEvent;
    }
    public Options[] OptionsInfo;

}
