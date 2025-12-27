using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;
    [SerializeField] SpriteFaceDirection spriteFace;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }


    public void DirectionChecker(Vector3 dir)
    {
        direction = dir.normalized;

        // Xoay Object cha để nó di chuyển về hướng đó (Logic 3D)
        float yAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, yAngle, 0f);

        // Cập nhật hướng cho Sprite (Logic Visual)
        if (spriteFace != null)
        {
            spriteFace.FaceDirection(direction);
        }
    }



}
