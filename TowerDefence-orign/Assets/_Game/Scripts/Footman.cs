using UnityEngine;
using System.Collections;

public class Footman : MonoBehaviour {

    Animator footman;
    void awake()
    {
        footman = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void die()
    {
        footman.SetTrigger("Die");
    }
}
