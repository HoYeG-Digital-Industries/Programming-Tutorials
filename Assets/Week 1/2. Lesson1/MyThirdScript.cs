using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyThirdScript : MonoBehaviour
{

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			for( int i = 0; i < transform.childCount; ++i )
			{
			transform.GetChild(i).gameObject.SetActive(false);
			}
						
			int tempNumber = Random.Range (0,transform.childCount);
			transform.GetChild(tempNumber).gameObject.SetActive(true);
		}
	}
}
