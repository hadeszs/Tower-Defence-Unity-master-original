using UnityEngine;
using System.Collections;

namespace TowerDefence {

	public class Projectile : MonoBehaviour {

		[SerializeField]
		private float speed;

		[SerializeField]
		private int damage;
		public int Damage {
			get { return damage; }
			private set { damage = value; }
		}

		private Transform target;
		private Vector3 dest;
		
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
			if( target != null ) {
				dest = target.position;
			}

			// move tarwrds target like a rocket.
			transform.position = Vector3.MoveTowards( transform.position, dest, speed * Time.deltaTime );

			// if there is no target, destroy when reach the targets old pos.
			if( Vector3.Distance( transform.position, dest ) < 0.05 ) {
				Destroy( gameObject );
			}
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Fires the specified target.
		/// </summary>
		/// <param name="target">The target.</param>
		public void Fire( Transform target ) {
			this.target = target;
			dest = target.position;
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================



	}
}