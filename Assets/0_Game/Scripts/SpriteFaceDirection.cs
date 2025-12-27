using UnityEngine;

public class SpriteFaceDirection : MonoBehaviour
{
    [Tooltip("Góc bù nếu sprite mặc định không nằm ngang (thường là -45, 0, hoặc 45)")]
    [SerializeField] float spriteForwardOffset = 0f;

    public void FaceDirection(Vector3 worldDir)
    {
        Vector3 camRight = Camera.main.transform.right;
        Vector3 camUp = Camera.main.transform.up;

        float dotX = Vector3.Dot(worldDir, camRight);
        float dotY = Vector3.Dot(worldDir, camUp);

        float angle = Mathf.Atan2(dotY, dotX) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(0, 0, angle + spriteForwardOffset);
    }
}