using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {

	public GameObject model;
	public SpriteRenderer sprite;
	public TMP_Text colourText;
	public TMP_Text instructionText;


	void Start()
	{
		instructionText.text = "PRESS R, G OR B";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			colourText.color = Color.red;
			colourText.text = "RED";
			model.GetComponent<MeshRenderer>().material.color = Color.red;
			sprite.color = Color.red;
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			colourText.color = Color.green;
			colourText.text = "GREEN";
			model.GetComponent<MeshRenderer>().material.color = Color.green;
			sprite.color = Color.green;
		}
		if (Input.GetKeyDown(KeyCode.B))
		{
			colourText.color = Color.blue;
			colourText.text = "BLUE";
			model.GetComponent<MeshRenderer>().material.color = Color.blue;
			sprite.color = Color.blue;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RandomColor();
		}	
		
	}

	private void RandomColor()
	{
			Color32 randomColor;
			byte colorR, colorG, colorB;
					
			colorR = ( byte )Random.Range( 0, 255 );
			colorG = ( byte )Random.Range( 0, 255 );
			colorB = ( byte )Random.Range( 0, 255 );			
			
			randomColor = new Color32 (colorR, colorG, colorB, 255);
		
			colourText.color = randomColor;
			colourText.text = "R" + colorR + " G" + colorG + " B" + colorB;
			model.GetComponent<MeshRenderer>().material.color = randomColor;
			sprite.color = randomColor;
	}
}
