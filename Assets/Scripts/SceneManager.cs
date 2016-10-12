using UnityEngine;
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

	GameState gameState;

	public Vector3 deltaEntryPlug=new Vector3(0,0.35f,0);
	// Use this for initialization
	void Start () {
		InstantiateAndDestroy (currentScene);
		RepositionateCharacters (false);
        Camera.main.transform.position = GetCameraCenter(currentScene);
        scnMng = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
		gameState = GameObject.Find ("GameState").GetComponent<GameState> ();


	}

	public void RepositionateCharacters(bool goingBack){
		Transform entrypoint;
		if (!goingBack) {
			entrypoint = scenes [currentScene].GetComponentInChildren<EntryScript> ().transform;
		} else {
			TransitionPointScript point = Array.Find (scenes [currentScene].GetComponentsInChildren<TransitionPointScript> (), item => item.goToScene == lastScene);
			point.DeactivateUntilExit ();
			entrypoint = point.transform;
		}
		orfeo.transform.position = entrypoint.position + deltaEntryPlug;
        orfeo.GetComponent<Rigidbody2D>().velocity = Vector3.zero; 
		orfeo.GetComponent<Movement> ().canGoLeft = true;
		orfeo.GetComponent<Movement> ().canGoRight = true;
		if (currentScene != 36)
			euridice.transform.position = entrypoint.position + delta + deltaEntryPlug;
        else
            euridice.transform.position = entrypoint.position+new Vector3(-0.5f,0,0);
    }

	public void SceneChange(int toScene,bool goingBack){
		if (!changing && toScene>=0) {
			InstantiateAndDestroy (toScene);
			changing = true;
			lastScene = currentScene;
			currentScene = toScene;
            delta = euridice.transform.position - orfeo.transform.position;
                
			RepositionateCharacters (goingBack);
			Time.timeScale = 0;
			StartCoroutine (CameraSliding (currentScene, () => {
				Debug.Log ("Transition Completed");
                Destroy(oldScene);
				changing=false;
				DialogsLevel tmp = currentsceneobj.GetComponent<DialogsLevel>();
				Time.timeScale = 1;
                currentsceneobj.GetComponent<LevelScript>().OnFinishedLoad();
				if(tmp!=null)
					tmp.ShowDialogs();
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

    public void DeathRespawn()
    {
        delta = (euridice.transform.position - orfeo.transform.position).normalized / 2; 
        RepositionateCharacters(false);

        if (currentsceneobj.transform.position.x > orfeo.transform.position.x)
        {
            orfeo.transform.localScale = new Vector3(1,transform.localScale.y,0);
            euridice.transform.localScale = new Vector3(1, transform.localScale.y, 0);
        }
        else
        {
            orfeo.transform.localScale = new Vector3(-1, transform.localScale.y, 0);
            euridice.transform.localScale = new Vector3(-1, transform.localScale.y, 0);
        }
    }

	Vector3 GetCameraCenter(int sceneIndex){
		return scenes [sceneIndex].GetComponentInChildren<CameraCenterScript> ().transform.position;
	}

	IEnumerator CameraSliding(int toSceneindex, Action callback){
		Vector3 destination = GetCameraCenter (toSceneindex);
		while(Vector3.Distance(Camera.main.transform.position,destination)>0.1f){
			Camera.main.transform.position = Vector3.MoveTowards (Camera.main.transform.position, destination, Time.fixedDeltaTime * speed);
			yield return new WaitForEndOfFrame ();
		}
		Camera.main.transform.position = destination;
		callback.Invoke ();
	}

	public static void ChangeScene(int scene,bool goingBack){
		scnMng.SceneChange (scene, goingBack);
	}

	public static void RespawnScene(){
		scnMng.DeathRespawn ();
	}

	public static void GoToLastCheckpoint(){
        GameObject.Find("GameState").GetComponent<GameState>().enemyState.Clear();
        GameObject.Find("GameOverPanel").GetComponent<GameOverPanel>().Activate();
        scnMng.speed *= 10000; 
		scnMng.SceneChange (scnMng.gameState.indexLastCheckpointVisited, false);
        scnMng.speed /= 10000;
    }
}
