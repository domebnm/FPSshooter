using Unity.VisualScripting;
using UnityEngine;

public class canvasEnemy : MonoBehaviour
{
    [SerializeField] Vector3 camPos;

    void LateUpdate()
    {
        transform.LookAt(camPos);
    }
}
