using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour, IInteractable
{
    [SerializeField] int questIndex = 0;
    [SerializeField] List<string> sentences = new List<string>();


    public void ProgressOnQuests()
    {
        if(questIndex < sentences.Count - 1)
        {
            questIndex++;
        }
    }

    public void Interact()
    {
        UIHandler.instance.MessageDisplayer(sentences[questIndex]);
    }
}
