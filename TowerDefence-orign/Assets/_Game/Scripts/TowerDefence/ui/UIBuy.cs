using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace TowerDefence.UI {

	public class UIBuy : AbsUIPopup {

		public delegate void DelegateBuyTurret( Enums.TurretType turretType, Vector3 position );
		public event DelegateBuyTurret EventBuy;		

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
		/// Shows the popup specified position.
		/// </summary>
		/// <param name="position">The position.</param>
		public override void Show( Vector3 position ) {
			base.Show( position );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Dispatches the turret type.
		/// </summary>
		/// <param name="turretType">Type of the turret.</param>
		private void TurretTypeSelected( Enums.TurretType turretType  ) {
			if( EventBuy != null ) {
				EventBuy( turretType, position );
			}
			OnClose();
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [buy a] clicked.
		/// </summary>
		public void OnBuyA() {
			TurretTypeSelected( Enums.TurretType.Type_A );			
		}

		/// <summary>
		/// Called when [buy b] clicked.
		/// </summary>
		public void OnBuyB() {
			TurretTypeSelected( Enums.TurretType.Type_B );
		}

	}
}
