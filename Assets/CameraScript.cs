using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float mouseSpeed;
    [SerializeField] Transform playerTr;

    
    float rotX = 0f, rotY = 0f;
    void Start()
    {
        Cursor.visible = false;
    }


    Vector2 mousePos
    {
        get
        {
            float mousePosX = Input.GetAxis("Mouse X") * mouseSpeed;
            float mousePosY = Input.GetAxis("Mouse Y") * mouseSpeed;

            return new Vector2(mousePosX, mousePosY);
        }
    }
    void Update()
    {     
        rotX -= mousePos.y;
        rotX = Mathf.Clamp(rotX, -90f, 90f);
        rotY += mousePos.x;

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        playerTr.rotation = Quaternion.Euler(0, rotY, 0);
    }
}
