using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class LoopsToMakeRoads : MonoBehaviour
{
	
	//Private Variables
	private int CenterRoadLength, RightBranchLength, LeftBranchLength, CrossBranchLength;
	
	[Header("Arrays")]
	public GameObject[] straightRoads;
	public GameObject[] endRoads;
	public GameObject[] crossRoads;
	public GameObject leftBranchRoad, rightBranchRoad;
	
	[Header("Variables")]
	[Range(0,1f)]
	public float GeneratorDelay;
	public int CenterRoadMinLength, CenterRoadMaxLength;
	public int BranchRoadMinLength, BranchRoadMaxLength;
	public int numberOfIterations;
	
	[Header("Objects We Need")]
	public GameObject spawnObject;
	public GameObject roadsContainer;
	
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(GenerateRoads());
	}
	
	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			string currentSceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(currentSceneName);
		}
	}
	
	
	IEnumerator GenerateRoads()
	{
		//Lets generate the length of the centre road
		CenterRoadLength = Random.Range(CenterRoadMinLength, CenterRoadMaxLength);
		
		//Lets Instantiate our magic spawn object
		GameObject centreRoadSpawnObject = Instantiate(spawnObject, this.transform); 
		centreRoadSpawnObject.transform.parent = null;
		
		
		//First lets put down a starting piece
		GameObject startRoadPiece = Instantiate(endRoads[Random.Range(0,endRoads.Length)], centreRoadSpawnObject.transform); //spawns an end road
		startRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
	
		//Now lets move our spawn object to where we want to start the loop from
		centreRoadSpawnObject.transform.localPosition = new Vector3(centreRoadSpawnObject.transform.localPosition.x - 1f, centreRoadSpawnObject.transform.localPosition.y, centreRoadSpawnObject.transform.localPosition.z);	


		for (int i = 0; i < numberOfIterations; i++)
		{
			
			//Lets spawn a bit of road
			for (int j = 0; j < CenterRoadLength; j++)
			{
				//Now lets spawn a centre road piece
				GameObject centerRoadPiece = Instantiate(straightRoads[Random.Range(0,straightRoads.Length)], centreRoadSpawnObject.transform); //spawns a centre road
				centerRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				centreRoadSpawnObject.transform.localPosition = new Vector3(centreRoadSpawnObject.transform.localPosition.x - 1f, centreRoadSpawnObject.transform.localPosition.y, centreRoadSpawnObject.transform.localPosition.z);
				yield return new WaitForSeconds(GeneratorDelay);
			}
			
			//now lets spawn a differnt bit of road but first we need to chose it. 
			float centerRoadCoinFlip;
			centerRoadCoinFlip = Random.Range(0,1f);

			if (centerRoadCoinFlip <= 0.33f)
			{
				//lets spawn a crossroads
				GameObject crossRoadPiece = Instantiate(crossRoads[Random.Range(0,crossRoads.Length)], centreRoadSpawnObject.transform); //spawns a centre road
				crossRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				//lets spawn two new spawn objects
				GameObject crossRightSpawnObject = Instantiate(spawnObject, centreRoadSpawnObject.transform); 
				GameObject crossLeftSpawnObject = Instantiate(spawnObject, centreRoadSpawnObject.transform); 
				crossRightSpawnObject.transform.parent = null;
				crossLeftSpawnObject.transform.parent = null;				
				crossRightSpawnObject.transform.localPosition = new Vector3(crossRightSpawnObject.transform.localPosition.x, crossRightSpawnObject.transform.localPosition.y, crossRightSpawnObject.transform.localPosition.z + 1f);
				crossLeftSpawnObject.transform.localPosition = new Vector3(crossLeftSpawnObject.transform.localPosition.x, crossLeftSpawnObject.transform.localPosition.y, crossLeftSpawnObject.transform.localPosition.z - 1f);
				centreRoadSpawnObject.transform.localPosition = new Vector3(centreRoadSpawnObject.transform.localPosition.x - 1f, centreRoadSpawnObject.transform.localPosition.y, centreRoadSpawnObject.transform.localPosition.z);
			
				CrossBranchLength = Random.Range(BranchRoadMinLength, BranchRoadMaxLength);
			
				//Lets spawn a cross branch
				for (int j = 0; j < CrossBranchLength; j++) 
				{
					GameObject crossBranchSubRightPiece =  Instantiate(straightRoads[Random.Range(0,straightRoads.Length)], crossRightSpawnObject.transform);; //spawns a centre road
					crossBranchSubRightPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
					crossBranchSubRightPiece.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
					crossRightSpawnObject.transform.localPosition = new Vector3(crossRightSpawnObject.transform.localPosition.x, crossRightSpawnObject.transform.localPosition.y, crossRightSpawnObject.transform.localPosition.z + 1f);
					yield return new WaitForSeconds(GeneratorDelay);
				
					GameObject crossBranchSubLeftPiece =  Instantiate(straightRoads[Random.Range(0,straightRoads.Length)], crossLeftSpawnObject.transform);; //spawns a centre road
					crossBranchSubLeftPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
					crossBranchSubLeftPiece.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
					crossLeftSpawnObject.transform.localPosition = new Vector3(crossLeftSpawnObject.transform.localPosition.x, crossLeftSpawnObject.transform.localPosition.y, crossLeftSpawnObject.transform.localPosition.z - 1f);
					yield return new WaitForSeconds(GeneratorDelay);
				}			

				GameObject rightCrossEndRoadPiece = Instantiate(endRoads[Random.Range(0,endRoads.Length)], crossRightSpawnObject.transform); //spawns an end road
				rightCrossEndRoadPiece.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self); //rotates the final piece
				rightCrossEndRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				Destroy(crossRightSpawnObject);	
			
				GameObject leftCrossEndRoadPiece = Instantiate(endRoads[Random.Range(0,endRoads.Length)], crossLeftSpawnObject.transform); //spawns an end road
				leftCrossEndRoadPiece.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self); //rotates the final piece
				leftCrossEndRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				Destroy(crossLeftSpawnObject);				
				yield return new WaitForSeconds(GeneratorDelay);
			
			
			} 
			else if (centerRoadCoinFlip > 0.33f && centerRoadCoinFlip <= 0.66f) 
			{
				//lets spawn a left branch
				GameObject leftBranchPiece = Instantiate(leftBranchRoad, centreRoadSpawnObject.transform); //spawns a centre road
				leftBranchPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				//Lets spawn a new spawn object
				GameObject leftRoadSpawnObject = Instantiate(spawnObject, centreRoadSpawnObject.transform); 
				leftRoadSpawnObject.transform.parent = null;
				leftRoadSpawnObject.transform.localPosition = new Vector3(leftRoadSpawnObject.transform.localPosition.x, leftRoadSpawnObject.transform.localPosition.y, leftRoadSpawnObject.transform.localPosition.z - 1f);
				centreRoadSpawnObject.transform.localPosition = new Vector3(centreRoadSpawnObject.transform.localPosition.x - 1f, centreRoadSpawnObject.transform.localPosition.y, centreRoadSpawnObject.transform.localPosition.z);
			
				LeftBranchLength = Random.Range(BranchRoadMinLength, BranchRoadMaxLength);
				
				//Lets spawn a right branch
				for (int j = 0; j < LeftBranchLength; j++) 
				{
					GameObject leftBranchSubPiece =  Instantiate(straightRoads[Random.Range(0,straightRoads.Length)], leftRoadSpawnObject.transform);; //spawns a centre road
					leftBranchSubPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
					leftBranchSubPiece.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
					leftRoadSpawnObject.transform.localPosition = new Vector3(leftRoadSpawnObject.transform.localPosition.x, leftRoadSpawnObject.transform.localPosition.y, leftRoadSpawnObject.transform.localPosition.z - 1f);
					yield return new WaitForSeconds(GeneratorDelay);
				}
			
				GameObject leftEndRoadPiece = Instantiate(endRoads[Random.Range(0,endRoads.Length)], leftRoadSpawnObject.transform); //spawns an end road
				leftEndRoadPiece.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self); //rotates the final piece
				leftEndRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				Destroy(leftRoadSpawnObject);			
				yield return new WaitForSeconds(GeneratorDelay);	
			}
			else if (centerRoadCoinFlip > 0.66f)
			{
				//lets spawn a right branch
				GameObject rightBranchPiece = Instantiate(rightBranchRoad, centreRoadSpawnObject.transform); //spawns a right road
				rightBranchPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				//Lets spawn a new spawn object
				GameObject rightRoadSpawnObject = Instantiate(spawnObject, centreRoadSpawnObject.transform); 
				rightRoadSpawnObject.transform.parent = null;
				rightRoadSpawnObject.transform.localPosition = new Vector3(rightRoadSpawnObject.transform.localPosition.x, rightRoadSpawnObject.transform.localPosition.y, rightRoadSpawnObject.transform.localPosition.z + 1f);
				centreRoadSpawnObject.transform.localPosition = new Vector3(centreRoadSpawnObject.transform.localPosition.x - 1f, centreRoadSpawnObject.transform.localPosition.y, centreRoadSpawnObject.transform.localPosition.z);
			
				RightBranchLength = Random.Range(BranchRoadMinLength, BranchRoadMaxLength);
				
				//Lets spawn a right branch
				for (int j = 0; j < RightBranchLength; j++) 
				{
					GameObject rightBranchSubPiece =  Instantiate(straightRoads[Random.Range(0,straightRoads.Length)], rightRoadSpawnObject.transform);; //spawns a centre road
					rightBranchSubPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
					rightBranchSubPiece.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
					rightRoadSpawnObject.transform.localPosition = new Vector3(rightRoadSpawnObject.transform.localPosition.x, rightRoadSpawnObject.transform.localPosition.y, rightRoadSpawnObject.transform.localPosition.z + 1f);
					yield return new WaitForSeconds(GeneratorDelay);
				}
			
				GameObject rightEndRoadPiece = Instantiate(endRoads[Random.Range(0,endRoads.Length)], rightRoadSpawnObject.transform); //spawns an end road
				rightEndRoadPiece.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self); //rotates the final piece
				rightEndRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned
				Destroy(rightRoadSpawnObject);
				yield return new WaitForSeconds(GeneratorDelay);
			}

			yield return new WaitForSeconds(GeneratorDelay);
		}
		//Now lets put down an end piece
		GameObject endRoadPiece = Instantiate(endRoads[Random.Range(0,endRoads.Length)], centreRoadSpawnObject.transform); //spawns an end road
		endRoadPiece.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self); //rotates the final piece
		endRoadPiece.transform.parent = roadsContainer.transform; //changes the parent object of the object spawned


		//Now lets remove the spawn object
		Destroy (centreRoadSpawnObject);
		

	}
	
	


}
