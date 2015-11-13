using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace TowerDefence {

	public class PlacementTile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

		public delegate void DelegateSelected( PlacementTile tile, Vector3 position );
		public event DelegateSelected EventSelected;

		[SerializeField]
		private Color rolloverColor = Color.white;
		
		private Color defaultColor;
		private Renderer rendererer;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			rendererer = GetComponentInChildren<Renderer>();
			defaultColor = rendererer.material.color;
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


		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================

		/// <summary>
		/// Called when [pointer click].
		/// </summary>
		/// <param name="eventData">The event data.</param>
		public void OnPointerClick( PointerEventData eventData ) {
			if( EventSelected != null ) {				
				EventSelected( this, transform.position );
			}
		}

		/// <summary>
		/// Called when [pointer enter].
		/// </summary>
		/// <param name="eventData">The event data.</param>
		public void OnPointerEnter( PointerEventData eventData ) {
			if( GameManager.instance.Money > 0 ) {
				rendererer.material.color = rolloverColor;
			}
		}

		/// <summary>
		/// Called when [pointer exit].
		/// </summary>
		/// <param name="eventData">The event data.</param>
		public void OnPointerExit( PointerEventData eventData ) {
			rendererer.material.color = defaultColor;
		}

	}

}