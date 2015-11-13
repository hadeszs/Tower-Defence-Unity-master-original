using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public delegate void Action();
	public event Action EventDamage;

	[SerializeField]
	private int health = 0;
	public int HealthValue {
		get { return health; }
		private set { health = value; }
	}

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
	/// Sets the starting health.
	/// </summary>
	/// <param name="value">The value.</param>
	public void SetStartingHealth( int value ) {
		HealthValue = value;
	}

	/// <summary>
	/// Applies Damage.
	/// </summary>
	/// <param name="value">The value.</param>
	public void Damage( int value ) {
		HealthValue -= value;

		if( EventDamage != null ) {
			EventDamage();
		}
	}

	//===================================================
	// PRIVATE METHODS
	//===================================================


	//===================================================
	// EVENTS METHODS
	//===================================================

	
}
