using UnityEngine;
using System;

namespace TowerDefence {

	public class Enemy : MonoBehaviour {

		public delegate void DelegateDestroy( Enemy enemy );
		public event DelegateDestroy EventDied;
		public event DelegateDestroy EventReachedTarget;

		public Texture2D red;
	    public Texture2D black;
		
		private Health health;
		private HitFlash hitFlash;
		private int startingHealth;
		private int maxHP;

        public GameObject footman;
        Animator a;


        bool isSinking;

        
        float time;
        int curParkTime = 0;//use to count time

        
        
//===================================================
// UNITY METHODS
//===================================================

/// <summary>
/// Awake.
/// </summary>
void Awake() {
			health = GetComponent<Health>();
			hitFlash = GetComponent<HitFlash>();
			startingHealth = health.HealthValue;
            a = footman.GetComponent<Animator>();
            
        }

		/// <summary>
		/// Start.
		/// </summary>
		void Start() {
			red=new Texture2D(50,3);
			for(int i=0;i<red.width;i++){
				for(int j=0;j<red.height;j++)
					red.SetPixel(i,j,Color.red);
			}
			red.Apply();
			black=new Texture2D(50,3);
			for(int i=0;i<black.width;i++){
				for(int j=0;j<black.height;j++)
					black.SetPixel(i,j,Color.black);
			}
			black.Apply();
			maxHP=health.HealthValue;
		}

		/// <summary>
		/// Update.
		/// </summary>
		void Update() {

            if (isSinking)
            {
                transform.Translate(-Vector3.up * Time.deltaTime);
                if (Time.time > time + 1f)
                {

                    time = Time.time;
                    curParkTime++;
                }
                if (curParkTime >= 2)
                {

                    Died();
                }
            }

        }

        void OnGUI(){
           
                Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + 25, transform.position.z);
                Vector2 position = GameObject.Find("Camera").GetComponent<Camera>().WorldToScreenPoint(worldPosition);
                position = new Vector2(position.x, Screen.height - position.y);
                Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(red));
                int blood_width = red.width * health.HealthValue / maxHP;
                GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - 2 * bloodSize.y, bloodSize.x, bloodSize.y), black);
                GUI.DrawTexture(new Rect(position.x - (bloodSize.x / 2), position.y - 2 * bloodSize.y, blood_width, bloodSize.y), red);

           

        }

		/// <summary>
		/// Called when [enable].
		/// </summary>
		void OnEnable() {
			health.SetStartingHealth( startingHealth );
		}

		/// <summary>
		/// Called when a the trigger is fired.
		/// </summary>
		/// <param name="collider">The collider.</param>
		void OnTriggerEnter( Collider collider ) {
			if( collider.gameObject.tag == Tags.Projectile ) {

				// apply the projectile damage.
				Projectile projectile = collider.gameObject.transform.parent.gameObject.GetComponent<Projectile>();
				health.Damage( projectile.Damage );

				// destroy the collidee - projectile
				Destroy( collider.gameObject.transform.parent.gameObject );
				
				hitFlash.Flash();

				// check health
				if( health.HealthValue <= 0 ) {


                   a.SetTrigger("Die");
                   GetComponent<NavMeshAgent>().enabled = false;
                   footman.GetComponent<BoxCollider>().enabled = false;
                   isSinking = true;
                    //Destroy(footman, 2f);

                    //Died();



                }
			} else if ( collider.gameObject.tag == Tags.Goal ) {
				ReachedTarget();
			}
		}

		//===================================================
		// PUBLIC METHODS
		//===================================================

		/// <summary>
		/// Sets the health value.
		/// </summary>
		/// <param name="value">The value.</param>
		public void SetHealthValue( int value ) {
			health.SetStartingHealth( value );
		}

		//===================================================
		// PRIVATE METHODS
		//===================================================

		/// <summary>
		/// Called when there is no health.
		/// </summary>
		private void Died() {
			if( EventDied != null ) {
				EventDied( this );
			}
		}

		/// <summary>
		/// Called when it reacheds the target.
		/// </summary>
		private void ReachedTarget() {
			if( EventReachedTarget != null ) {
				EventReachedTarget( this );
			}
		}

		//===================================================
		// EVENTS METHODS
		//===================================================
		

	}
}