using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float rotationSpeed = 5.0f;


    public float minVerticalAngle;
    public float maxVerticalAngle;
    public bool CanMove = true;
    Vector3 lookAtPosition;
    public float currentZoomDistance;

 
    void Update()
    {

        PlayerMove();

    }

    private void LateUpdate()
    {
        MoveToTarget();
    }

    
    private void PlayerMove()
    {

            if (target != null && CanMove)
            {
                float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
                float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

                // Вращение вокруг цели по горизонтали
                transform.RotateAround(target.position, Vector3.up, mouseX);

                // Вращение вокруг камеры по вертикали
                


            }


    }

    private void MoveToTarget()
    {

            Vector3 desiredPosition = target.position - transform.forward * currentZoomDistance;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);

    }
   
}
