using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BaseUI : MonoBehaviour
{
    protected Dictionary<string, RectTransform> rectTransforms;
    protected Dictionary<string, Button> buttons;
    protected Dictionary<string, TMP_Text> texts;
    // TODO : add ui component

    private void Awake()
    {
        Bind();
    }
    private void Bind()
    {
        RectTransform[] children = GetComponentsInChildren<RectTransform>();

        foreach(RectTransform child in children)
        {
            string name = child.gameObject.name;

            if (rectTransforms.ContainsKey(name)) continue;
            rectTransforms.Add(name, child);

            Button button = child.GetComponent<Button>();
            if(button != null)
                buttons.Add(name, button);
            
            TMP_Text text = child.GetComponent<TMP_Text>();
            if(text != null)
                texts.Add(name, text);  
            
            // TODO : add ui component
        }
    }
}
