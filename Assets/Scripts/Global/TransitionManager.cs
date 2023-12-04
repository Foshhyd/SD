using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TransitionManager : MonoBehaviour
{
    public void SceneLoad(string sceneName)
    {
        //Camera movement before scene transition

        StartCoroutine(LoadLevelASync(sceneName));
    }

    IEnumerator LoadLevelASync(string sceneName)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);

        while (loadOperation != null)
        {
            yield return null;
        }
    }
}
