using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class MyFirstScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Debug.Log ("HELLO WORLD"); //This will print HELLO WORLD into the console when the script is initialized
		
		//MySecondScript.speed = 100; //Ignore me for now. I will get back to me.
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.Log ("I AM UPDATING..."); //This will print I AM UPDATING... to the console every frame
	}
}
