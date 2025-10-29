using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private NPCDialogue dialogueData;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText, nameText;
    [SerializeField] private Image portraitImage;

    private int _dialogueIndex;
    private bool _isTyping, _isDialogueActive;

    public bool CanInteract() => !_isDialogueActive;

    public void Interact()
    {
        if (_isDialogueActive)
        {

        }
        else
        {

        }
    }

    private void Start()
    {
        _isDialogueActive = true;
        _dialogueIndex = 0;

        nameText.SetText(dialogueData.npcName);
        portraitImage.sprite = dialogueData.npcPortrait;

        dialoguePanel.SetActive(true);
        StartCoroutine(TypeLine());

    }

    private IEnumerator TypeLine()
    {
        _isTyping = true;
        dialogueText.SetText("");

        foreach(char letter in dialogueData.dialogueLines[_dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        _isTyping = false;
    }
}
