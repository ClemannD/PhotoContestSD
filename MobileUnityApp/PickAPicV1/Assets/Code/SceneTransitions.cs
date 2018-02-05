using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitions{
	public static Stack<int> pastScenes = new Stack<int>();//the int represents the build settings index

	public static void NextScene(int nextSceneIndex){
		int currSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;


		pastScenes.Push (currSceneBuildIndex);
		SceneManager.LoadScene (nextSceneIndex);
	}

	public static void GoBack(){
		if (pastScenes.Count > 0) {
			SceneManager.LoadScene (pastScenes.Pop ());
		}
	}
}
