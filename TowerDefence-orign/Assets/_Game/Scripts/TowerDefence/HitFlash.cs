using UnityEngine;
using System.Collections;

public class HitFlash : MonoBehaviour {

	[SerializeField]
	private float duration = 0.1f;

	[SerializeField]
	private Color hitColor = Color.white;

	private Color normalColor;
	private Renderer rendererer;

	//===================================================
	// UNITY METHODS
	//===================================================

	/// <summary>
	/// Awake.
	/// </summary>
	void Awake () {
		rendererer = GetComponentInChildren<Renderer>();
		normalColor = rendererer.material.color;
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
	/// Flashes this instance.
	/// </summary>
	public void Flash() {
		rendererer.material.color = hitColor;
		Invoke( "Reset", duration );
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================

	/// <summary>
	/// Resets this instance.
	/// </summary>
	private void Reset() {
		rendererer.material.color = normalColor;
	}

	//===================================================
	// EVENTS METHODS
	//===================================================

	
}
