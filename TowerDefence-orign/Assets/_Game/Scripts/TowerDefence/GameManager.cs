using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TowerDefence {

	public class GameManager : MonoBehaviour {
		public static GameManager instance = null;

		[SerializeField]
		private Transform projectileContainer;
		public Transform ProjectileContainer {
			get { return projectileContainer; }
			private set { projectileContainer = value; }
		}

		public List<GameObject> EnemyList {
			get { return spawnManager.EnemyList; }
		}
		
		[SerializeField]
		private Transform goal;
		public Transform Goal {
			get { return goal; }
		}

		[SerializeField]
		private PlacementTile[] placementTiles;

		[SerializeField]
		private float difficultyInterval = 3.0f;

		[SerializeField]
		private int health = 10;
		public int Health {
			get { return health; }
			private set { health = value; }
		}

		[SerializeField]
		private int money = 15;
		public int Money {
			get { return money; }
			private set { money = value; }
		}		

		[SerializeField]
		private int enemyHealthIncrease = 1;		

		[SerializeField]
		private float initialDelay = 3.0f;		

		public int SpawnCount {
			get { return spawnManager.SpawnCount; }
		}

		private TurretManager turretManager;
		private SpawnManager spawnManager;
		private UIManager uiManager;
		private PlacementTile currentSelectedTile;
		private bool isActive;

		//===================================================
		// UNITY METHODS
		//===================================================

		/// <summary>
		/// Awake.
		/// </summary>
		void Awake() {
			# region - Singlton
			if( instance == null ) {
				instance = this;
			} else if( instance != this ) {
				Destroy( gameObject );
			}
			DontDestroyOnLoad( gameObject );
			# endregion

			uiManager = GetComponentInChildren<UIManager>();
			turretManager = GetComponentInChildren<TurretManager>();
			spawnManager = GetComponentInChildren<SpawnManager>();
		}

		/// <summary>
		/// Start.
		/// </summary>
		void Start() {
			isActive = true;

			for( int i = 0; i < placementTiles.Length; i++ ) {
				PlacementTile tile = placementTiles[ i ];
				tile.EventSelected += OnPlacementTileClicked;
			}

			uiManager.EventBuyTurret += CreateTurret;
			uiManager.UpdateHud();

			spawnManager.EventSpawned += OnEnemySpawn;
			spawnManager.EventReachedTarget += OnEnemyReachedTarget;
			spawnManager.EventDied += OnEnemyDied;

			Invoke( "StartGame", initialDelay );
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
		/// Starts the game.
		/// </summary>
		public void ResetGame() {
			Health = 10;
			Money = 15;
			spawnManager.Reset();
			turretManager.Reset();
			uiManager.UpdateHud();
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Starts the game.
		/// </summary>
		private void StartGame() {
			spawnManager.StartSpawning();
			StartCoroutine( IncreaseDifficulty() );
		}

		/// <summary>
		/// Creates a turret.
		/// </summary>
		/// <param name="turretType">Type of the turret.</param>
		/// <param name="position">The position.</param>
		private void CreateTurret( Enums.TurretType turretType, Vector3 position ) {
			currentSelectedTile.enabled = false;
			turretManager.CreateTurret( turretType, position );

			int cost = 0;
			switch( turretType ) {
				case Enums.TurretType.Type_A:
					cost = turretManager.TurretCostA;
					break;
				case Enums.TurretType.Type_B:
					cost = turretManager.TurretCostB;
					break;
			}
			money -= cost;
			uiManager.UpdateHud();
		}


		/// <summary>
		/// Increases the difficulty.
		/// </summary>
		/// <returns></returns>
		private IEnumerator IncreaseDifficulty() {
			while( isActive ) {
				spawnManager.EnemyHealth += enemyHealthIncrease;
				yield return new WaitForSeconds( difficultyInterval );
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================

		
		/// <summary>
		/// Called when [placement tile clicked].
		/// </summary>
		/// <param name="tile">The tile.</param>
		/// <param name="position">The position.</param>
		private void OnPlacementTileClicked( PlacementTile tile, Vector3 position ) {
			if( money > 0 ) {
				currentSelectedTile = tile;
				uiManager.ShowBuyUI( position );
			}
		}

		/// <summary>
		/// Called when [enemy spawn].
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnEnemySpawn() {
			uiManager.UpdateHud();
		}

		/// <summary>
		/// Called when [enemy reached target].
		/// </summary>
		/// <exception cref="System.NotImplementedException"></exception>
		private void OnEnemyReachedTarget() {
			Health -= 1;
			uiManager.UpdateHud();

			if( health <= 0 ) {
				uiManager.ShowGameOver();
			}
		}


		/// <summary>
		/// Called when [enemy died].
		/// </summary>
		/// <param name="enemyMoney">The enemy money.</param>
		private void OnEnemyDied( int enemyMoney ) {
			Money += enemyMoney;
			uiManager.UpdateHud();
		}

	}
}