using UnityEngine;
using System.Collections;


public class Main : MonoBehaviour {


	void Start () {
		Screen.lockCursor = true;

		GetComponent<Renderer> ().enabled = false;

	}

	void test () {
		Debug.Log ("TEST");
	}
	
	// Update is called once per frame
	void Update() {

	}
}
