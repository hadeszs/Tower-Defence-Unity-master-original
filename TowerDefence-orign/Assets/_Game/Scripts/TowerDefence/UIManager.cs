using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TowerDefence.UI;

namespace TowerDefence {

	public class UIManager : MonoBehaviour {

		public delegate void DelegateBuyTurret( Enums.TurretType turretType, Vector3 position );
		public event DelegateBuyTurret EventBuyTurret;

		[SerializeField]
		private UIBuy uiBuy;

		[SerializeField]
		private UIHud uiHUD;

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
			uiBuy.EventBuy += OnBuy;
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
		/// Shows the buy UI.
		/// </summary>
		/// <param name="position">The position.</param>
		public void ShowBuyUI( Vector3 position ) {
			uiBuy.Show( position );
		}

		/// <summary>
		/// Updates the hud.
		/// </summary>
		public void UpdateHud() {
			uiHUD.UpdateHud();
		}

		public void ShowGameOver() {

		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [buy button is clicked].
		/// </summary>
		/// <param name="turretType">Type of the turret.</param>
		/// <param name="position">The position.</param>
		private void OnBuy( Enums.TurretType turretType, Vector3 position ) {
			// reduce the money
			if( EventBuyTurret != null ) {
				EventBuyTurret( turretType, position );
			}
		}

	}
}
