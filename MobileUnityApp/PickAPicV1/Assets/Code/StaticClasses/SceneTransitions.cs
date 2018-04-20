using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransitions{
	private const int MAX_SCENES_STACK = 600;


	private static int[] keepTheseScenes = {SceneIndices.ENTRIES, SceneIndices.PAST_CONTESTS};


	public static Stack<int> pastScenes = new Stack<int>();//the int represents the build settings index

	public static void NextScene(int nextSceneIndex){
		if (pastScenes.Count == MAX_SCENES_STACK) {
			CleanSceneStack (pastScenes, pastScenes.Count / 4);
		}


		int currSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

		//bool keepThisScene = false;
		//for (int i = 0; i < keepTheseScenes.Length; i++) {
		//	if (keepTheseScenes [i] == currSceneBuildIndex) {
		//		keepThisScene = true;
		//		break;
		//	}
		//}

		//if(keepThisScene && pastScenes.Contains()

		pastScenes.Push (currSceneBuildIndex);

		//if(keepThisScene && pastScenes.Contains(currSceneBuildIndex){
		//	SceneManager
		//}
		SceneManager.LoadScene (nextSceneIndex);
	}


	/// <summary>
	/// use this to remove older values in the stack. Will remove values starting at the bottom of the stacks going up, until 
	/// there are no more values or we have reached "num trim", whichever comes first.
	/// </summary>
	private static void CleanSceneStack(Stack<int> sceneStack, int numTrim){
		sceneStack.Clear ();
		if (numTrim >= sceneStack.Count) {
			return;
		}

		int[] stackStuff = sceneStack.ToArray ();

		for (int i = numTrim; i < stackStuff.Length; i++) {
			sceneStack.Push (stackStuff[i]);
		}
			


	}

	public static void NextSceneKeepCurrent(){

	}

	public static int LastScene(){
		return pastScenes.Peek ();
	}

	public static void GoBack(){
		if (pastScenes.Count > 0) {
			SceneManager.LoadScene (pastScenes.Pop ());
		}
	}
}
