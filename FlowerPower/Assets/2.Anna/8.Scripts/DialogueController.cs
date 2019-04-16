using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueController : MonoBehaviour
{
    //access panel, enable and disabe on certaint higns.
    //if "Sunny: " is in front, enable sunny speech icon

    private int index;
    private bool finishedSentence;

    public float typingSpeed;
    public string[] dialogueArray;
    public TextMeshProUGUI textOnScreen; //Might need to change this too normal UI
    public GameObject sunnyProfile;
    public GameObject rosieProfile;

    void Start()
    {
        StartCoroutine(TypingLetters());
    }

    private void Update()
    {
        if (dialogueArray[index].Contains("Sunny:"))
        {
            sunnyProfile.SetActive(true);
            rosieProfile.SetActive(false);
        }

        if (dialogueArray[index].Contains("Rosie:"))
        {
            sunnyProfile.SetActive(false);
            rosieProfile.SetActive(true);
        }

        if (textOnScreen.text == dialogueArray[index]) //If the whole sentence has been printed
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
            textOnScreen.text += letter; //access the TexhMeshPro object then add a letter everytime the coroutine runs.
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Next()
    {
        if (index < dialogueArray.Length -1) //Check if the index is at the end of the story arc
        {
            index++;
            textOnScreen.text = ""; //Resets the text to blank
            StartCoroutine(TypingLetters());
        }

        else //If there is no story left, set to blank.
        {
            textOnScreen.text = ""; 
        }
    }
}