using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))] public class SetTiles : MonoBehaviour { public Vector2 tiling;
	void Start () {
		GetComponent<MeshRenderer>().material.mainTextureScale = tiling;
	}    
}