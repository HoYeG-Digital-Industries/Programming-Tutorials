using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeneratingMachine : MonoBehaviour
{

	[Header("RandomWords")]
	public string[] Words;
	public TMP_Text PlaceForWord;
	[Header("RandomColors")]
	public Color32[] Colours;
	public Image colourMe;
	[Header("RandomSprites")]
	public Sprite[] Sprites;
	public Image PlaceForSprite;
	[Header("RandomFloat")]
	public TMP_Text PlaceForFloat;
	[Header("RandomInt")]
	public TMP_Text PlaceForInt;
	[Header("RandomAll")]
	public TMP_Text RandomAllText;
	public Image RandomAllImage;



	public void WordGenerator()
	{
		PlaceForWord.text = Words[Random.Range(0, Words.Length)];
	}

	public void ColourGenerator()
	{
		colourMe.color = Colours[Random.Range(0, Colours.Length)];
	}

	public void SpriteGenerator()
	{
		PlaceForSprite.sprite = Sprites[Random.Range(0, Sprites.Length)];
	}
	
	public void FloatGenerator()
	{
		float tempFloat;
		tempFloat = Random.Range(0, 100f);
		PlaceForFloat.text = tempFloat.ToString();
	}

	public void IntGenerator()
	{
		float tempInt;
		tempInt = Random.Range(0, 10000000f);
		PlaceForInt.text = tempInt.ToString();
	}
	
	public void RandomAllGenerator()
	{
		int tempInt;
		tempInt = Random.Range(0,5); //Can someone tell me why I put 5 in here even though if we count from 0 that would be 6? 
		
		switch (tempInt)
		{
			case 0:
			{
				RandomAllText.text = Words[Random.Range(0, Words.Length)];
				RandomAllImage.sprite = null; 
				RandomAllImage.color = new Color32(255, 255, 255, 255);
				break;
			}
			case 1:
			{
				RandomAllImage.color = Colours[Random.Range(0, Colours.Length)];
				RandomAllText.text = "";
				RandomAllImage.sprite = null;
				break;
			}
			case 2:
			{
				RandomAllImage.sprite = Sprites[Random.Range(0, Sprites.Length)];
				RandomAllText.text = "";
				RandomAllImage.color = new Color32(255, 255, 255, 255);
				break;
			}
			case 3:
			{
				RandomAllImage.sprite = null;
				RandomAllImage.color = new Color32(255, 255, 255, 255);
				float tempFloat;
				tempFloat = Random.Range(0, 10000000f);
				RandomAllText.text = tempFloat.ToString();
				break;
			}
			case 4:
			{
				RandomAllImage.sprite = null;
				RandomAllImage.color = new Color32(255, 255, 255, 255);
				float tempInt1;
				tempInt1 = Random.Range(0, 10000000f);
				RandomAllText.text = tempInt1.ToString();
				break;
			}			
		}
		
		
	}

}
