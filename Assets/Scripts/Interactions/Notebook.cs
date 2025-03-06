using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour, IInteractable
{
    [SerializeField] private int _questIndex;
    [SerializeField] private List<string> sentences = new List<string>();

    public void ProgressOnQuests()
    {
        if(_questIndex < sentences.Count - 1)
        {
            _questIndex++;
        }
    }

    public void Interact()
    {
        UIHandler.Instance.MessageDisplayer(sentences[_questIndex]);
    }
}
