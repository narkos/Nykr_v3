using UnityEngine;
using System.Collections;

public abstract class PlayerCollisionEvent : Event {
	[HideInInspector]
	public Collider[] potColliders;
	public float collisionRadius = 20;


	public virtual void Initialize(){
		base.Initialize ();

	}
	/**
	void CheckPlayerCollision(){
		potColliders = Physics.OverlapSphere (thisTransform, collisionRadius);
		int i = 0;
		bool checker = false;
		while (i < potColliders.Length) {
			if(potColliders [i].tag == "Player"){
				checker = true;
			}
			i++;
		}

		if (checker == true) {
			is_Colliding = true;
		} else
			is_Colliding = false;

	}**/


}
