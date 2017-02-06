using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour {

    Transform transform;
    Vector3 moveVector;
    Vector3 startPos;

    // Use this for initialization
    void Start () {
        transform = GetComponent<Transform>();
        moveVector = new Vector3(0, -0.1f, 0);
        startPos = transform.position;
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
