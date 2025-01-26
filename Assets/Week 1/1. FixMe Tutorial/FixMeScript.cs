/*using System.Collections;
using System.Collections.Generic;
using Something;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class IsThisTheWrongName : MonoBehaviour
{

	public Image bg;
	public GameObject congratsText;
	public TMP_Text AddOnetext;
	public TMP_Text RandomNameText;
	public Toggle ColorChange;
	private int Add1Number;
	private float timer
	public string[] names =    {"Sandra Key",
								"Chaz Novak",
								"Reid Nash",
								"Baron Allison",
								"German Rodgers",
								"Dustin Carey",
								"Thalia Stokes",
								"Nathalie Bruce",
								"Cindy Burch",
								"Brisa Moore",
								"Genesis Levine",
								"Madeleine Cohen",
								"Allyson Rosales",
								"Jacquelyn Williamson",
								"Abdullah Norman",
								"Tabitha Gillespie",
								"Rodrigo Hunt",
								"Hayley Crosby",
								"Yesenia Eaton",
								"Lena Herman"
								};

	void Awake() 
	{
		congratsText.transform.localScale = new Vector2(0,0,0);
		Debug.Log(This is not the right way to write a debug statement)
	}


	// Start is called before the first frame update
	void start()
	{
		Vector3 newScale = new Vector3 (1,1,1);
		StartCoroutine(LerpScale(newScale, 1f));
		Add1text.text = Add1Number.ToString();
	}

	// Update is called once per frame
	void Update()
	{


		if (ColorChange.isOn == true && timer == 200f)
		{
			ChangeTheSkybox();
		}

		timer ++;

		if (timer > 200f){
			timer = 0;
		
	}

	IEnumerator LerpScale(Vector3 targetLocalScale, float duration)
	{
		var StartScale = congratsText.transform.localScale;

		for(var timePassed = 0f; timePassed < duration; timePassed += Time.deltaTime)
		{
			var factor = timePassed / duration;
			factor = Mathf.SmoothStep(0, 1, factor);

			congratsText.transform.localScale = Vector3.Lerp(startScale, targetLocalScale, factor);

			yield return null;
		}

		congratsText.transform.localScale = targetLocalScale;
	}

	public void Add1Button() 
	{
		Add1Number ++;
		Add1text.text = Add1Number.ToString();
	}

	public void PickAName()
	{
		RandomNameText.text = names[Random.Range(0, names.Length)];
	}

	void ChangeSkybox()
	{
	   bg.color = new Color (Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
		
	}


*/