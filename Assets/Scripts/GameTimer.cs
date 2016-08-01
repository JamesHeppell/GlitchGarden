using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	
	public AudioClip audioClip;
	public float levelTimer = 100f;
	
	private LevelManager levelManager;
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	private GameObject[] allGameObjects;
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		audioSource = GetComponent<AudioSource>();
		
		slider = GetComponent<Slider>();
		slider.value = 0f;
		
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin (){
		winLabel = GameObject.Find ("Win Message");
		if (!winLabel) {
			Debug.LogWarning ("please create a win message");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value += Time.deltaTime /levelTimer;
		//slider.value = Time.timeSinceLevelLoad / levelTimer;
		
		if (slider.value >=1 && !isEndOfLevel){
		
			isEndOfLevel = true;
			HandleWinCondition ();
		}
	}
	
	void HandleWinCondition (){
		DestroyAllTaggedObjects();
		audioSource.Play ();
		winLabel.SetActive (true);
		isEndOfLevel = true;
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}
	
	//Destroys all objects with the tag destroyOnWin
	void DestroyAllTaggedObjects(){
		allGameObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject taggedObject in allGameObjects){
			Destroy (taggedObject);
		}
	}
	
	void LoadNextLevel (){
		levelManager.LoadNextLevel();
	}
}
