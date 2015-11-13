using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TowerDefence {

	public class TurretManager : MonoBehaviour {

		[SerializeField]
		private Transform turretContainer;

		[SerializeField]
		private GameObject turretPrefabA;

		[SerializeField]
		private GameObject turretPrefabB;

		[SerializeField]
		private int turretCostA = 1;
		public int TurretCostA {
			get { return turretCostA; }
		}

		[SerializeField]
		private int turretCostB = 2;
		public int TurretCostB {
			get { return turretCostB; }
		}

		private List<GameObject> turrets;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {

		}

		/// <summary>
		/// Start.
		/// </summary>
		void Start() {
			turrets = new List<GameObject>();
		}

		/// <summary>
		/// Update.
		/// </summary>
		void Update() {

		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Creates a turret.
		/// </summary>
		/// <param name="turretType">Type of the turret.</param>
		/// <param name="position">The position.</param>
		public void CreateTurret( Enums.TurretType turretType, Vector3 position ) {
			GameObject tempGO = null;
			switch( turretType ) {
				case Enums.TurretType.Type_A:
					tempGO = turretPrefabA;
					break;
				case Enums.TurretType.Type_B:
					tempGO = turretPrefabB;
					break;
				default:
					tempGO = turretPrefabA;
					break;
			}

			GameObject turretGO = Instantiate( tempGO, position, Quaternion.identity ) as GameObject;
			turretGO.transform.SetParent( turretContainer );

			turrets.Add( turretGO );
		}

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset() {
			for( int i = 0; i < turrets.Count; i++ ) {
				Destroy( turrets[ i ] );
			}
			turrets.Clear();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}
