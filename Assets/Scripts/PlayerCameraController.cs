using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    
    public float smoothing;
    
    public float lookSensitivity;
    
    public float minYRotation = -90;

    public float maxYRotation = 90;

    public GameObject pauseMenu;

    private GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.activeSelf)
        {
            RotateCamera();
        }
        
        
    }

    public void RotateCamera()
    {
        Vector2 inputValues = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        inputValues = Vector2.Scale(inputValues, new Vector2(lookSensitivity * smoothing, lookSensitivity * smoothing));

        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f / smoothing);

        currentLookingPosition += smoothedVelocity;

        currentLookingPosition.y = Mathf.Clamp(currentLookingPosition.y, minYRotation, maxYRotation);

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPosition.y, Vector3.right);

        player.transform.localRotation = Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);


    }
}
