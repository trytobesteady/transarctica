using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TrainControl : MonoBehaviour {
	
	private GameObject train;

	private GameObject fuelIndicator;
	private GameObject directionIndicator;

	private int direction = -1;
	private float fuel = 0;
	//private float fuelIndicatorAmount = 0;
	private float fuelDistanceMultiplier = 10;

	void Start () {
		train = GameObject.Find ("train");
		fuelIndicator = GameObject.Find ("indicator");
		directionIndicator = GameObject.Find ("setDirection");
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
	}

	
	public void addFuel (string label) {

		fuel++;
		fuelIndicator.transform.Translate(0, fuel/10, 0);
		moveTrain ();

	}

	public void switchDirection () {

		direction = direction * (-1);
		directionIndicator.transform.Rotate (180, 0, 0, Space.World);

	}
	

	void moveTrain() {
		train.transform.DOMoveZ (fuelDistanceMultiplier*fuel*direction, fuelDistanceMultiplier*fuel).SetRelative ();
		fuelIndicator.transform.DOMoveX (fuelIndicator.transform.position.x, fuelDistanceMultiplier*1).OnComplete(burnFuel);
	}

	void burnFuel() {

		fuelIndicator.transform.Translate(0, -(fuel/10), 0);

		if (fuel <= 0) {
			fuel = 0;
		} else {
			fuel--;
		}
	}


	void Update () {}

}
