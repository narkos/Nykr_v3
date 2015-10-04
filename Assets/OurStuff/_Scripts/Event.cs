using UnityEngine;
using System.Collections;

public abstract class Event : MonoBehaviour {
	[HideInInspector]
	public Transform player;
	[HideInInspector]
	public Transform thisTransform;

	//hur ofta eventet kan köras
	public float cooldown_Of_Event;
	[HideInInspector]
	public float cooldown_Event_Timer;
	/**
	Event e = Event.current;
	if (e.isKey)
		Debug.Log("Detected key code: " + e.keyCode);
		**/

	public virtual void Initialize(){
		StopAllCoroutines ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		thisTransform = this.transform;
	}
/**
	[HideInInspector]
	public bool is_Colliding; //med tex en checkbox
	[HideInInspector]
	public bool is_Raycasting; //framför spelaren
**/

	public bool is_collideEvent = false;
	public bool is_raycastEvent = true;

	public virtual bool StartEvent(){
		if (cooldown_Event_Timer > Time.time)
			return false;
		else {
			cooldown_Event_Timer = Time.time + cooldown_Of_Event;
			return true;
		}
	}
	public abstract void PlayerInteract(); //denna kallas när spelaren försöker påverka eventet, alla subklasser kommer inte att ha funktionallitet för denna
	public abstract void Interact(); //kallas när spelaren kolliderar eller liknande med denne, alla subklasser kommer inte att ha funktionallitet för denna

	public abstract void Reset();
}
