using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UIElements;

// Camera Movement of WorldSpace
public class CameraController : MonoBehaviour
{
    [Header("Ballancing")]
    [SerializeField]
    private Vector2 mousePos;
    [SerializeField]
    private Vector3 mouseDir;
    [SerializeField]
    private Vector3 keyboardDir;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float padding;
    [SerializeField]
    private float maxZoomIn;
    [SerializeField]
    private float minZoomIn;

    private float scrResolutionX;
    private float scrResolutionY;

    private void Awake()
    {
        scrResolutionX = Screen.width;
        scrResolutionY = Screen.height; 
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        KeyboardMove();
        MouseMove();
    }

    #region Input Action
    private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();

        keyboardDir.x = inputDir.x;
        keyboardDir.z = inputDir.y;
    }
    private void KeyboardMove()
    {
        transform.Translate(keyboardDir * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnPointer(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }
    private void MouseMove()
    {
        // Move Horizontal
        if (mousePos.x < padding)
            mouseDir.x = -1;
        else if (mousePos.x > scrResolutionX - padding)
            mouseDir.x = 1;
        else
            mouseDir.x = 0;

        // Move Vertical
        if (mousePos.y < padding)
            mouseDir.z = -1;
        else if (mousePos.y > scrResolutionY - padding)
            mouseDir.z = 1;
        else
            mouseDir.z = 0;

        transform.Translate(mouseDir * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnZoom(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
    }
    private void Zoom(InputValue value)
    {

    }

    #endregion
}
