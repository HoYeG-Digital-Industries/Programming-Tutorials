using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RandomNumber : MonoBehaviour {

	//Set up all your variables first

	public TMP_Text Answer;
	public TMP_InputField AnswerGiven;
	string AnswerGivenString;

	int NumberToGuess;

	// Use this for initialization
	void Start () {
		
		//Sets up the number to guess by randomly chosen a number (int) between 0 and 100;
		NumberToGuess = Random.Range (0,100);

	}
	
	
	//This checks your entered answer
	public void CheckAnswer(){
		Debug.Log(AnswerGiven);
		//Set up the variables for this function
		int EnteredAnswer;
		
		//Grabs the text entered and converts it to a string variable
		AnswerGivenString = AnswerGiven.text.ToString();
				
		//Tries to convert the strong variable to a number (int)
		int.TryParse(AnswerGivenString, out EnteredAnswer);

		//CheckAnswer to see if you are correct
		
		if (EnteredAnswer == NumberToGuess){
			Answer.text = "YOU WIN";

		}

		if (EnteredAnswer > NumberToGuess){
			Answer.text = "TRY LOWER";

		}

		if (EnteredAnswer < NumberToGuess){
			Answer.text = "TRY HIGHER";
			
		}

	}
}
