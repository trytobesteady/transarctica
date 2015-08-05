using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour {
	
	public string TargetObject;
	public string TargetFunction;
	public bool flag;
	public string Label;
	
	private Color oldColor;
	private Text hudInfo;
	private GameObject targetObject;
	
	void Start() {
		hudInfo = GameObject.Find("hud_info").GetComponent<Text>();
		targetObject = GameObject.Find(TargetObject);
	}
	
	void OnMouseEnter() {
		oldColor = GetComponent<Renderer> ().material.color;
		GetComponent<Renderer>().material.color = Color.yellow;
		hudInfo.text = Label;
	}
	
	void OnMouseExit() {
		GetComponent<Renderer> ().material.color = oldColor;
		hudInfo.text = "";
	}
	
	void OnMouseDown(){
		targetObject.SendMessage(TargetFunction, Label);
	}
}