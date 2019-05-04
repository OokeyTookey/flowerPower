using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TurnOffGameObject : MonoBehaviour
{
    public DialogueController dialougeController;
    public TextMeshProUGUI textBox;

    DialogueFeeder feeder;
    public TextMeshProUGUI objectiveTextBox;
    public GameObject objectivePanel;

    private void Start()
    {
        feeder = this.gameObject.GetComponent<DialogueFeeder>();
    }

    //public string currentObjective;

           //  objectiveTextBox.SetText(currentObjective);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textBox.text = ""; //Resets the text to blank

            dialougeController.dialogueArray = null;
            dialougeController.dialogueArray = new string[feeder.sentences.Length];
            dialougeController.dialogueArray = feeder.sentences;
            dialougeController.index = 0;
            dialougeController.panel.SetActive(true);
            dialougeController.StartCoroutine(dialougeController.TypingLetters());
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
