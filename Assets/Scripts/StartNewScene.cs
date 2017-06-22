using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewScene : MonoBehaviour {

	public void LoadScenes(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
