using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour {

    public GameObject RoadStart, Road1, Road2, Road3, Road4, Road5, Road6, Road7, Road8, Road9, Road10;
    public GameObject grid;
	private Vector3 RoadOffset = new Vector3(0, 10, 0);
	private Vector3 OldPosition = new Vector3(0, 0, 0);
	private int framecount = 0;

	// Use this for initialization
	void Start () {
    GameObject NewRoad = Instantiate(RoadStart, transform.position - RoadOffset, Quaternion.identity);
    NewRoad.transform.parent = grid.transform;
    NewRoad = Instantiate(RoadStart, transform.position, Quaternion.identity);
	NewRoad.transform.parent = grid.transform;
    OldPosition = NewRoad.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (framecount % 120 == 0){
			int RandomRoad = Random.Range (1, 11);
			OldPosition += RoadOffset;
			GameObject NewRoad;
			switch (RandomRoad) {
			case 1:
				NewRoad = Instantiate (Road1, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 2:
				NewRoad = Instantiate (Road2, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 3:
				NewRoad = Instantiate (Road3, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 4:
				NewRoad = Instantiate (Road4, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 5:
				NewRoad = Instantiate (Road5, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 6:
				NewRoad = Instantiate (Road6, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 7:
				NewRoad = Instantiate (Road7, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 8:
				NewRoad = Instantiate (Road8, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 9:
				NewRoad = Instantiate (Road9, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;
			case 10:
				NewRoad = Instantiate (Road10, OldPosition, Quaternion.identity);
				NewRoad.transform.parent = grid.transform;
				break;

			};
		}
        framecount++;

    }
}
