using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text nameText;
    public TMPro.TMP_Text sentencesText;

    private Queue<string> sentences;

    public AudioSource typing;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public GameObject continueButton;
    public void StartDialogue(Dialogue dialogue)
    {

        nameText.text = dialogue.codeName;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        continueButton.SetActive(true);
    }

    IEnumerator TypeSentence(string sentence)
    {
        sentencesText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            sentencesText.text += letter;
            typing.Play();
            yield return null;
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public static bool endDialogue = false;

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        endDialogue = true;
    }


}
