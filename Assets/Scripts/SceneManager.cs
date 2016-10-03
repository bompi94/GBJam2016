﻿using UnityEngine;
using System.Collections;
using System;

public class SceneManager : MonoBehaviour {

	public GameObject[] scenes;

	public int currentScene=0;
	public int lastScene=0;
	public GameObject orfeo;
	public GameObject euridice;
	public Vector3 delta;
	public float speed = 5;
	public bool changing = false;
	public static SceneManager scnMng;
	// Use this for initialization
	void Start () {
		RepositionateCharacters (false);
		scnMng = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
	}

	void RepositionateCharacters(bool goingBack){
		Transform entrypoint;
		if (!goingBack) {
			entrypoint = scenes [currentScene].GetComponentInChildren<EntryScript> ().transform;
		} else {
			TransitionPointScript point = Array.Find (scenes [currentScene].GetComponentsInChildren<TransitionPointScript> (), item => item.goToScene == lastScene);
			point.DeactivateUntilExit ();
			entrypoint = point.transform;
		}
		orfeo.transform.position = entrypoint.position;
		euridice.transform.position = entrypoint.position + delta;
	}

	public void SceneChange(int toScene,bool goingBack){
		if (!changing && toScene>=0) {
			changing = true;
			lastScene = currentScene;
			currentScene = toScene;
			RepositionateCharacters (goingBack);
			StartCoroutine (CameraSliding (currentScene, () => {
				Debug.Log ("Transition Completed");
				changing=false;
			}));
		}
	}

	public void ReinitScene(){
		SceneChange (currentScene, false);
	}

	Vector3 GetCameraCenter(int sceneIndex){
		return scenes [sceneIndex].GetComponentInChildren<CameraCenterScript> ().transform.position;
	}

	IEnumerator CameraSliding(int toSceneindex, Action callback){
		Vector3 destination = GetCameraCenter (toSceneindex);
		while(Vector3.Distance(Camera.main.transform.position,destination)>0.1f){
			//Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, destination, Time.deltaTime * speed);
			Camera.main.transform.position = Vector3.MoveTowards (Camera.main.transform.position, destination, Time.deltaTime * speed);
			yield return new WaitForEndOfFrame ();
		}
		Camera.main.transform.position = destination;
		callback.Invoke ();
	}

	public static void ChangeScene(int scene,bool goingBack){
		scnMng.SceneChange (scene, goingBack);
	}

	public static void RespawnScene(){
		scnMng.ReinitScene ();
	}

	public static void UnityStronzo(){
		Debug.Log ("Unity è uno stronzo");
	}
}