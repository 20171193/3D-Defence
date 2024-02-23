using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        EnsureEventSystem();
    }

    public void EnsureEventSystem()
    {
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if(eventSystem == null)
        {
            GameObject ob = Instantiate(gameObject);
            ob.AddComponent<EventSystem>();
        }
    }

}
