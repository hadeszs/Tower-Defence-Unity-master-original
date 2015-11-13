using UnityEngine;
using System.Collections;

namespace TowerDefence {

	public class MoveTowardsGoal : MonoBehaviour {

		[SerializeField]
		private float speed;

		private NavMeshAgent navMeshAgent;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			navMeshAgent = GetComponent<NavMeshAgent>();
			navMeshAgent.speed = speed;		
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
		/// Sets the nav agents destinatin
		/// </summary>
		public void StartMoving() {
			// recieve cached Goal to save dynamic Find.
            if(GetComponent<NavMeshAgent>().enabled == true)
            {
                navMeshAgent.SetDestination(GameManager.instance.Goal.position);
            }
			
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================


		//===================================================
		// EVENTS METHODS
		//===================================================


	}
}