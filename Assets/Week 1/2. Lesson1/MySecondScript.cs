using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySecondScript : MonoBehaviour {

	public static int speed = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.right * Time.deltaTime * speed);

        // ...also rotate around the World's Y axis
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
	}
}
