using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace TowerDefence.UI {


	public class UIHud : MonoBehaviour {

		[SerializeField]
		private Text health;

		[SerializeField]
		private Text money;

		[SerializeField]
		private Text spawncount;

		private GameManager gameManager;

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
			gameManager = GameManager.instance;
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
		/// Updates the hud.
		/// </summary>
		public void UpdateHud() {
			health.text = gameManager.Health.ToString();
			spawncount.text = gameManager.SpawnCount.ToString();
			money.text = gameManager.Money.ToString();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}