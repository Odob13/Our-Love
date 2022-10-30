using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public AudioClip soundEffects;
    public GameObject Player;
    private AudioSource audioSource;
    public Animator animator;
    public GameObject button;

    private Queue<string> sentences;
    private Button buttonui;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        buttonui= button.GetComponent<Button>();
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Staring coversation with"+ dialogue.name);

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        audioSource.clip = soundEffects;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        buttonui.enabled= false;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text= "";
        foreach (char letter in sentence.ToCharArray())
        {   
            if(letter == ',')
            {
                audioSource.Play();
                dialogueText.text+= letter;
                yield return new WaitForSeconds(0.2f);
            }
            else if(letter == '.')
            {
                audioSource.Play();
                dialogueText.text+= letter;
                yield return new WaitForSeconds(0.3f);
            }
            else if(letter == '-')
            {
                audioSource.Play();
                dialogueText.text+= letter;
                yield return new WaitForSeconds(1f);
            }
            else
            {
                audioSource.Play();
                dialogueText.text+= letter;
                yield return new WaitForSeconds(0.08f);
            }
        }
        buttonui.enabled= true;
    }

    public void OnExit()
    {
        audioSource.clip = null;
        animator.SetBool("IsOpen", false);
    }

    void EndDialogue()
    {
        audioSource.clip = null;
        animator.SetBool("IsOpen", false);
        Debug.Log("End of dialogue");
    }

}
