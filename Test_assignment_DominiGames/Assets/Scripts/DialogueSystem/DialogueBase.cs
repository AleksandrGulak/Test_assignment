using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string MyName;
        public Sprite Portrait;
        [TextArea(4, 8)]
        public string MyText;
    }
    [Header("Insert dialogue information below.")]
    public Info[] DialogueInfo;
}
