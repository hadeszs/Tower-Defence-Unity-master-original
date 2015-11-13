using UnityEngine;
using System.Collections;

public class CameraMoving : MonoBehaviour {
	public int Maxws=20;
	public int ws=0;//use to count how many times moving, max is 20
	public int Maxad=10;
	public int ad=0;//use to count how many times moving, max is 10
	public int MoveSpeed=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)&&ws<Maxws){
			ws++;
			Vector3 newVector=transform.position;
			newVector.z+=20;
			transform.position=newVector;
		}
		if(Input.GetKey(KeyCode.S)&&ws>0){
			ws--;
			Vector3 newVector=transform.position;
			newVector.z-=20;
			transform.position=newVector;
		}
		if(Input.GetKey(KeyCode.A)&&ad>-Maxad){
			ad--;
			transform.Translate(Vector3.left*Time.deltaTime*MoveSpeed);
		}
		if(Input.GetKey(KeyCode.D)&&ad<Maxad){
			ad++;
			transform.Translate(Vector3.right*Time.deltaTime*MoveSpeed);
		}
		
		if(ws==Maxws)
			ws=Maxws;
		if(ws==0)
			ws=0;
	    if(ad==Maxad)
			ad=Maxad;
		if(ad==-Maxad)
			ad=-Maxad;
	}
}
