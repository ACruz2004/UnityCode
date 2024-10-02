using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public TMP_Text nameOf;
    public string[] dialogue;
    private int index;
    public GameObject continueButton;
    public float wordSpeed;
    public bool playerIsClose;

    void Update() {
        if (playerIsClose) {
            if (dialoguePanel.activeInHierarchy) {
                zeroText();
            } else {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (dialogueText.text == dialogue[index]) {
            continueButton.SetActive(true);
        }
    }

    public void zeroText() {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing() {
        foreach (char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void nextLine() {
        continueButton.SetActive(false);
        if (index < dialogue.Length - 1) {
            ++index;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerIsClose = false;
            zeroText();
        }
    }
}