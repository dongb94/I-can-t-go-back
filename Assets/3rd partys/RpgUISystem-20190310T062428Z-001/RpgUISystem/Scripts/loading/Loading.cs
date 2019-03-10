using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadingScene()
    {
        LoadingSceneManager.LoadScene("LoadingScene");
    }

    public void GoIconScene()
    {
        SceneManager.LoadScene("IconScene");
    }
}
