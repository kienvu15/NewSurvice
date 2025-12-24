using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0;
        transform.forward = camForward;
    }
}
