using UnityEngine;
using System.Collections;
using System;

public class SceneManager : MonoBehaviour {

	public GameObject[] scenes;

	public int currentScene=0;

	public GameObject orfeo;
	public GameObject eurice;
	public Vector3 delta;
	public float speed = 5;
	public bool changing = false;
	// Use this for initialization
	void Start () {
		RepositionateCharacters ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void RepositionateCharacters(){
		Transform entrypoint = scenes [currentScene].GetComponentInChildren<EntryScript> ().transform;
		orfeo.transform.position = entrypoint.position;
		eurice.transform.position = entrypoint.position + delta;
	}

	public void OnSceneChange(){
		if (!changing) {
			changing = true;
			currentScene++;
			RepositionateCharacters ();
			StartCoroutine (CameraSliding (currentScene, () => {
				Debug.Log ("Transition Completed");
				changing=false;
			}));
		}
	}

	Vector3 GetCameraCenter(int sceneIndex){
		return scenes [sceneIndex].GetComponentInChildren<CameraCenterScript> ().transform.position;
	}

	IEnumerator CameraSliding(int toSceneindex, Action callback){
		Vector3 destination = GetCameraCenter (toSceneindex);
		Debug.Log ("Going to " + destination);
		while(Vector3.Distance(Camera.main.transform.position,destination)>0.1f){
			//Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, destination, Time.deltaTime * speed);
			Camera.main.transform.position = Vector3.MoveTowards (Camera.main.transform.position, destination, Time.deltaTime * speed);
			yield return new WaitForEndOfFrame ();
		}
		Camera.main.transform.position = destination;
		callback.Invoke ();
	}
}
