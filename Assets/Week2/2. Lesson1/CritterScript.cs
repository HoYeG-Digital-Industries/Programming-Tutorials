using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterScript : MonoBehaviour
{
	private SpawnCritter gameScript;
	// Start is called before the first frame update
	void Start()
	{
		gameScript = GameObject.Find("GameManager").GetComponent<SpawnCritter>(); //grabs the SpawnCritter component
		
		if (!gameScript.RandomObject){
			GetComponent<Renderer>().material.color = new Color (Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); //randomises the colour
		}
	}
	
	private void Update() {
		if (transform.position.y < -10f)
		{
			Destroy(this.gameObject); //destroys the game object
		}
	}
	


}
