using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBallAC : MonoBehaviour {

    LaserHazard laserHazard;

	void Start () {
        laserHazard = GetComponentInChildren<LaserHazard>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
