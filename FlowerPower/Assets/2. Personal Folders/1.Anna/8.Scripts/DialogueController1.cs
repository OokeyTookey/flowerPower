using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueController1 : MonoBehaviour
{
    //access panel, enable and disabe on certaint higns.
    //if "Sunny: " is in front, enable sunny speech icon

    private int index;
    private bool finishedSentence;

    public GameObject textPanel;
    public float typingSpeed;
    public string[] dialogueArray;

    public TextMeshProUGUI textBox;
    public GameObject sunnyProfile;
    public GameObject rosieProfile;

    public Transform sunnyTextLocation;
    public Transform rosieTextLocation;
    public Transform centerTextLocation;
    public float lerpSpeedText;
    public Animator objectivePanelAni;
    public Animator panelMovement;

    AnnaPlayerMovement playerMovement;
    bool doOnce;

    private void Start()
    {
        //ReStart();
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        StartCo();
    }

   public void ReStart()
    {
        textPanel.SetActive(false);
        sunnyProfile.SetActive(false);
        rosieProfile.SetActive(false);

        //objectivePanelAni.SetTrigger("FinishedObjective");
    }

    public void StartCo()
    {

        if (!doOnce)
        {
            textPanel.SetActive(true); //Change to play animation
            StartCoroutine(TypingLetters());
            doOnce = true;
        }
    }

    private void Update()
    {
        //---------------------------------------------------- ICONs / Text Componants -------------------------------------------------------
        if (doOnce)
        {

            if (dialogueArray[index].Contains("Sunny:"))
            {
                textPanel.transform.position = Vector3.Lerp(transform.position, sunnyTextLocation.position, lerpSpeedText);
                sunnyProfile.SetActive(true);
                rosieProfile.SetActive(false);
            }

            else if (dialogueArray[index].Contains("Rosie:"))
            {
                sunnyProfile.SetActive(false);
                rosieProfile.SetActive(true);
                textPanel.transform.position = Vector3.Lerp(transform.position, rosieTextLocation.position, lerpSpeedText);
            }

            else
            {
                sunnyProfile.SetActive(false);
                rosieProfile.SetActive(false);
                textPanel.transform.position = Vector3.Lerp(transform.position, centerTextLocation.position, lerpSpeedText);
            }
        }

        //Checks if the entire sentence has been printed, if so, set the bool to true.
        if (textBox.text == dialogueArray[index])
        {
            finishedSentence = true;
        }

        if (Input.GetButton("Submit") && finishedSentence == true)
        {
            finishedSentence = false;
            Next();
        }
    }

    IEnumerator TypingLetters()
    {
        //Foreach will allow us to access a specfic variable type in statements. IE: Each letter in a sentence.
        foreach (var letter in dialogueArray[index].ToCharArray()) //ToCharArray copies the chars and put them into unicode (readable)
        {
            textBox.text += letter; //access the TexhMeshPro object then add a letter everytime the coroutine runs.
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Next()
    {
        if (index < dialogueArray.Length - 1) //Check if the index is at the end of the story arc
        {
            index++;
            textBox.text = ""; //Resets the text to blank
            StartCoroutine(TypingLetters());
        }

        else //If there is no story left, set to blank N disable
        {
            textBox.text = "";
            sunnyProfile.SetActive(false);
            rosieProfile.SetActive(false);
            textPanel.SetActive(false);


            doOnce = false;
            //make player move
            //set NEW OBJECTIVE
        }
            Debug.Log(playerMovement.move);
    }
}