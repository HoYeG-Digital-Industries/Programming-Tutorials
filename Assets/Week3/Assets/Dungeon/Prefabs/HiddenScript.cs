using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       for( int i = 0; i < transform.childCount; ++i )
			{
			transform.GetChild(i).gameObject.SetActive(false);
			}
						
			int tempNumber = Random.Range (0,transform.childCount);
			transform.GetChild(tempNumber).gameObject.SetActive(true); 
    }


}
