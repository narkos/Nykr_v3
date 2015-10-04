using UnityEngine;
using System.Collections;

public class PlayerEventChecker : MonoBehaviour {
	private Transform thisTransform; //kommer nog inte vara spelaren utan kameran

	private Collider[] potColliders;
	public float collisionRadius = 20;

	private Camera mainCamera;
	private Ray rayMiddleScreen;
	private RaycastHit hit;

	private Event currentInteractEvent; //det eventet som saker kommer hända på vid denna frame
	public float interactRange = 10;
	public KeyCode interactKey = KeyCode.E;
	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		thisTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		CheckForEvent ();

		if (currentInteractEvent != null) {
			currentInteractEvent.Interact(); //kallas varje frame bara man kolliderar eller liknande
			if (Input.GetKeyDown (interactKey)) {
				currentInteractEvent.PlayerInteract ();
			}
		}


	}


	void CheckForEvent(){

		if (CheckRaycast () == true)
			return;
		if (CheckCollision () == true)
			return;

		//om den inte hitta nått event
		currentInteractEvent = null;
	}

	bool CheckRaycast(){
		rayMiddleScreen = mainCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0.5f));
		if (Physics.Raycast (rayMiddleScreen, out hit, interactRange)) {
			if (hit.collider.tag == "Event") {
				if(hit.collider.GetComponent<Event> ().is_raycastEvent == true){
					currentInteractEvent = hit.collider.GetComponent<Event> ();
					return true;
				}
			}

		}
		return false;
	}

	bool CheckCollision(){
		potColliders = Physics.OverlapSphere (thisTransform.position, collisionRadius);
		int i = 0;
		//bool checker = false;
		while (i < potColliders.Length) {
			if(potColliders [i].tag == "Event"){
				if(potColliders[i].GetComponent<Event>().is_collideEvent == true){
					currentInteractEvent = potColliders[i].GetComponent<Event>();
					return true;
				}
			}
			i++;
		}
		return false;
	}

}
