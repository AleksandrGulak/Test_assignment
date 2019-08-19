using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class References : MonoBehaviour
{
    public static References InstanceOfReferences;

    private void Awake()
    {
        if(InstanceOfReferences == null)
        {
            InstanceOfReferences = this;
        }
    }

    public GameObject TestGameObject;
    public Scene SceneToLoad;
}
