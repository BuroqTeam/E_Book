using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForEarth : MonoBehaviour
{
	public Transform target1;
	public Transform target2;// the object to rotate around
	public int speed; // the speed of rotation

	void Start()
	{
		if (target1 == null)
		{
			target1 = this.gameObject.transform;
			Debug.Log("RotateAround target not specified. Defaulting to parent GameObject");
		}
	}

	// Update is called once per frame
	void Update()
	{
		// RotateAround takes three arguments, first is the Vector to rotate around
		// second is a vector that axis to rotate around
		// third is the degrees to rotate, in this case the speed per second
		transform.RotateAround(target1.transform.position, target1.transform.up, speed * Time.deltaTime);
		transform.RotateAround(target2.transform.position, target2.transform.up, speed * Time.deltaTime);
	}
}
