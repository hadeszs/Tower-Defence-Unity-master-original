using UnityEngine;
using System.Collections;

public class AbsUIPopup : MonoBehaviour {

	protected Vector3 position;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {

	}

	/// <summary>
	/// Start.
	/// </summary>
	void Start () {
		
	}
	
	/// <summary>
	/// Update.
	/// </summary>
	void Update () {
		
	}

	//===================================================
	// PUBLIC METHODS
	//===================================================

	/// <summary>
	/// Shows the popup specified position.
	/// </summary>
	/// <param name="position">The position.</param>
	public virtual void Show( Vector3 position ) {
		this.position = position;
		Vector3 pos = Camera.main.WorldToScreenPoint( position );
		transform.position = pos;

		gameObject.SetActive( true );
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================


	//===================================================
	// EVENTS METHODS
	//===================================================

	/// <summary>
	/// Called when [close].
	/// </summary>
	public void OnClose () {
		gameObject.SetActive( false );
	}
}
