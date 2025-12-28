using UnityEngine;

public class TrunkTrigger : MonoBehaviour
{
    MapController mapController;
    [SerializeField] GameObject parentChunk; // Kéo Prefab cha vào đây

    void Start()
    {
        mapController = Object.FindFirstObjectByType<MapController>();

        // Nếu không kéo tay, tự lấy object cha
        if (parentChunk == null) parentChunk = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Thông báo cho MapController rằng player đã đổi vùng
            mapController.OnPlayerEnterNewChunk(parentChunk);
        }
    }
}