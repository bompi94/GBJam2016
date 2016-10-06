﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class SceneManager : MonoBehaviour {

	public GameObject[] scenes;

	public Dictionary<int,GameObject> scenesInstatiated = new Dictionary<int,GameObject> ();
	public int currentScene=0;
	public int lastScene=0;
	public GameObject orfeo;
	public GameObject euridice;
	public Vector3 delta;
	public float speed = 5;
	public bool changing = false;
	public static SceneManager scnMng;
    GameObject oldScene;

	public GameObject currentsceneobj;
	// Use this for initialization
	void Start () {
		InstantiateAndDestroy (currentScene);
		RepositionateCharacters (false);
        Camera.main.transform.position = GetCameraCenter(currentScene);
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
			InstantiateAndDestroy (toScene);
			changing = true;
			lastScene = currentScene;
			currentScene = toScene;
            delta = euridice.transform.position - orfeo.transform.position;
                
			RepositionateCharacters (goingBack);
			StartCoroutine (CameraSliding (currentScene, () => {
				Debug.Log ("Transition Completed");
                Destroy(oldScene);
				changing=false;
			}));
		}
	}

	public void InstantiateAndDestroy(int scene){
		//dalla scena corrente controlla se sono instanziate le scene necessarie e se c'è bisogno di distruggere qualcosa
		if (currentsceneobj != null) {
            oldScene = currentsceneobj;
		}
		currentsceneobj = Instantiate(scenes [scene]);		
	}
	/*
	public void InstantiateAndDestroy(int scene){
		Debug.Log ("Find something to Instantiate/Destroy, Going to "+scene);
		//dalla scena corrente controlla se sono instanziate le scene necessarie e se c'è bisogno di distruggere qualcosa
		if (!scenesInstatiated.ContainsKey (scene)) {
			scenesInstatiated.Add (scene, Instantiate (scenes [scene]));
			Debug.Log ("Instantiating scene " + scene);
		}
		GameObject sceneObj=scenesInstatiated[scene];
		TransitionPointScript[] portals = sceneObj.GetComponentsInChildren<TransitionPointScript> ();
		if (portals != null) {
			int[] transitions=Array.ConvertAll<TransitionPointScript,int> (portals, (item) => {
				return item.goToScene;
			});
			foreach (int transition in transitions) {
				if (!scenesInstatiated.ContainsKey (transition)) {
					Debug.Log ("Instantiating scene " + transition);
					scenesInstatiated.Add (transition, Instantiate (scenes [transition]));
				}
			}
			foreach(int key in scenesInstatiated.Keys){
				if(!transitions.Contains(key) && key!=scene){
					Debug.Log ("Destroing scene " + key);
					Destroy (scenesInstatiated [key]);
					scenesInstatiated.Remove (key);
				}
			}
		}
	}
*/
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
