using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialougeManager : MonoBehaviour
{
    public AudioSource clicksound;
    [SerializeField] private float typingSpeed = 0.008f;

    [SerializeField] private TextMeshProUGUI npcDialougeText;
    [SerializeField] private string[] npcDialougeSentences;
    [SerializeField] private GameObject continueButton;

    [SerializeField] private Animator npcSpeechBubbleAnimator;

    private int npcIndex;
    private float speechBubbleAnimDelay = 0.6f;

    private Movement movement;

    private void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

    public void TriggerStartDialouge()
    {
        movement.enabled = false;
        StartCoroutine(StartDialouge());
    }

    public IEnumerator StartDialouge()
    {
        movement.ToggleInteraction();
        npcSpeechBubbleAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(speechBubbleAnimDelay);
        StartCoroutine(TypeNpcDialouge());
        continueButton.SetActive(false);
    }
    private IEnumerator TypeNpcDialouge()
    {
        foreach(char letter in npcDialougeSentences[npcIndex].ToCharArray())
        {
            npcDialougeText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueButton.SetActive(true);
    }

    public IEnumerator ContinueNPCDialouge()
    {

        npcDialougeText.text = string.Empty;
        npcSpeechBubbleAnimator.SetTrigger("Close");
        yield return new WaitForSeconds(speechBubbleAnimDelay);
        npcDialougeText.text = string.Empty;
        npcSpeechBubbleAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(speechBubbleAnimDelay);
        continueButton.SetActive(false);

        npcIndex++;
        StartCoroutine(TypeNpcDialouge());
    }

    public void TriggerContinueNPCDialouge()
    {
        clicksound.Play();
        continueButton.SetActive(false);
        movement.enabled = true;
        if(npcIndex >= npcDialougeSentences.Length - 1)
        {
            npcDialougeText.text = string.Empty;
            npcSpeechBubbleAnimator.SetTrigger("Close");

            movement.ToggleInteraction();
        }
        else
        {
            StartCoroutine(ContinueNPCDialouge());
        }
    }
}
