using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

    Transform transform;
    Vector3 moveVector;
    Vector3 startPos;

	// Use this for initialization
	void Start () {
        transform = GetComponent<Transform>();
        moveVector = new Vector3(0, -0.1f, 0);
        startPos = new Vector3(-0.03f, 10.15f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(moveVector);
	}

    private void OnBecameInvisible()
    {
        transform.position = startPos;
    }
}
