using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class TriggerDetect : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private LayerMask tilemapLayer;
    [SerializeField] private float rayLength = 1f;
    [SerializeField] private UnityEvent onTriggerEnter;
    

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject != tilemap.gameObject) return;
        Debug.Log($"OnTriggerEnter2D {collider.gameObject.name}");
        CheckRaycast(Vector2.up);
        CheckRaycast(new Vector2(1f,1f));
        CheckRaycast(Vector2.down);
        CheckRaycast(new Vector2(1f,-1f));
        CheckRaycast(Vector2.left);
        CheckRaycast(new Vector2(-1f,1f));
        CheckRaycast(Vector2.right);
        CheckRaycast(new Vector2(-1f,-1f));
    }

    void CheckRaycast(Vector2 direction)
    {
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y);
        var hits = Physics2D.RaycastAll(rayStart, direction, rayLength, tilemapLayer);

        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                Vector3Int cellPosition = tilemap.WorldToCell(hit.point);
                TileBase tile = tilemap.GetTile(cellPosition);
                if (tile != null)
                {
                    tilemap.SetTile(cellPosition, null);
                    onTriggerEnter.Invoke();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 rayStart = new Vector2(transform.position.x, transform.position.y);

        Gizmos.DrawLine(rayStart, rayStart + Vector2.up * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + new Vector2(1f,1f) * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + Vector2.down * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + new Vector2(1f,-1f) * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + Vector2.left * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + new Vector2(-1f,1f) * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + Vector2.right * rayLength);
        Gizmos.DrawLine(rayStart, rayStart + new Vector2(-1f,-1f) * rayLength);
    }
}