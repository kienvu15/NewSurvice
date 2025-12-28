using UnityEngine;

public class SpriteDirection : MonoBehaviour
{
    public void SetDirection(Vector3 dir)
    {
        // vì sprite vẽ theo trục X
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
