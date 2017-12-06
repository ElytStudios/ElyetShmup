using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBallAC : MonoBehaviour {

    public LaserHazard[] laserHazard;
	
    public void LasersOn()
    {
        for (int i = 0; i < laserHazard.Length; ++i)
        {
            laserHazard[i].laserOn();
        }
    }

    public void LasersOff()
    {
        for (int i = 0; i < laserHazard.Length; ++i)
        {
            laserHazard[i].laserOff();
        }
    }
}
