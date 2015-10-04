using UnityEngine;
using System.Collections;

public class EventDoor : Event {
	public float maxYRot = 90;
	public float minYRot = 0;
	public float rotationSpeed = 1;

	private float startRotation;

	public Transform door;

	public KeyCode doorKey1 = KeyCode.Mouse0;
	public KeyCode doorKey2 = KeyCode.Mouse1;
	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	public override void Initialize ()
	{
		startRotation = door.rotation.y;
		Reset ();
	}
	
	public override bool StartEvent(){
		if (Input.GetKey (doorKey1)) {
			door.Rotate (0, Time.deltaTime * rotationSpeed, 0);
		} else if(Input.GetKey (doorKey2)){
			door.Rotate (0, Time.deltaTime * -rotationSpeed, 0);
		}

		if (door.rotation.eulerAngles.y > maxYRot) {
			door.rotation = Quaternion.Euler (door.rotation.x, maxYRot, door.rotation.z);
		} else if (door.rotation.eulerAngles.y < minYRot) {
			door.rotation = Quaternion.Euler (door.rotation.x, minYRot, door.rotation.z);
		}

		return true;
	}

	public override void PlayerInteract(){

	}
	public override void Interact(){
		StartEvent ();
	}
	
	public override void Reset(){
		door.rotation = Quaternion.Euler(door.rotation.x, startRotation, door.rotation.z);
	}

}
