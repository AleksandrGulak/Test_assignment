using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(fileName = "New Event", menuName = "Event")]

public class EventBehavior : ScriptableObject
{
    public void DestroyReferencedObj()
    {
        Destroy(References.InstanceOfReferences.TestGameObject);
        Debug.Log("Referenced Object Destroyed");
    }

    public void LoadReferencedScene()
    {
        SceneManager.LoadScene(References.InstanceOfReferences.SceneToLoad.handle);
        Debug.Log("Loadind Referenced Scene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Has quit the game");
    }

    public void TestEvent()
    {
        Debug.Log("Test event2 successful");
    }
}
