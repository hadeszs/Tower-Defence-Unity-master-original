using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace TowerDefence {

	public class Turret : MonoBehaviour {

		[SerializeField]
		private GameObject projectilePrefab;

		[SerializeField]
		private float fireRate = 1.0f;

		private TargetFinder targetFinder;
		private Transform projectileContainer;
		private bool isActive;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			targetFinder = GetComponent<TargetFinder>();
		}

		/// <summary>
		/// Start.
		/// </summary>
		void Start() {
			isActive = true;
			projectileContainer = GameManager.instance.ProjectileContainer;
			Invoke( "StartLookingForTargets", 1.0f );			
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

		/// <summary>
		/// Starts the looking for targets.
		/// </summary>
		private void StartLookingForTargets() {
			StartCoroutine( LookForTarget() );
		}

		/// <summary>
		/// Looks for target and if found calls fire.
		/// </summary>
		/// <returns></returns>
		private IEnumerator LookForTarget() {
			while( isActive ) {
				Transform target = targetFinder.Find();
				if( target != null  ) {
					FireAtTarget( target );
				}
				yield return new WaitForSeconds( fireRate );
			}
		}

		/// <summary>
		/// Createsa projectile.
		/// </summary>
		/// <param name="target">The target.</param>
		private void FireAtTarget( Transform target ) {
			Vector3 position = transform.position;
			position.y += 0.4f;

			GameObject projectileGO = Instantiate( projectilePrefab, position, Quaternion.identity ) as GameObject;
			projectileGO.transform.SetParent( projectileContainer );

			Projectile projectile = projectileGO.GetComponent<Projectile>();
			projectile.Fire( target );
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

	}

}
