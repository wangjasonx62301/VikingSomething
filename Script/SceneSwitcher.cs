using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    public int SceneIndexDestination = 0;

    public void OnPointerClick(PointerEventData e)
    {
        // current scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Current : " + scene.name + ", index : " + scene.buildIndex);

        // load new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
