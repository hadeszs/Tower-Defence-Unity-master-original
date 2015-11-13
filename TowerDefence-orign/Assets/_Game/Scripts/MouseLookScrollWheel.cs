using UnityEngine;
using System.Collections;

public class MouseLookScrollWheel : MonoBehaviour {
/*
let camera can move up or down, just like WOW
*/
	public int MaxCount=15;
	public int Count=0;//use to count how many times scroll, max is 20
	public float Distance=0f;
	public float ScrollFactor=20f;//the rate that mouse scroll wheel
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		var scrollAmount=Input.GetAxis("Mouse ScrollWheel");
		Distance=scrollAmount*ScrollFactor;
		
		if(scrollAmount<0&&Count<MaxCount){
			Count++;
			transform.position=transform.position-Vector3.up*Distance;
			transform.Rotate(1,0,0);
		}
		if(scrollAmount>0&&Count>-MaxCount){
			Count--;
			transform.position=transform.position-Vector3.up*Distance;
			transform.Rotate(-1,0,0);
		}
		if(Count==MaxCount)
			Count=MaxCount;
		if(Count==-MaxCount)
			Count=-MaxCount;
	}
}
