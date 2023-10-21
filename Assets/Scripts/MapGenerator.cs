using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    [AssetSelector]
    public List<Tile> groundTiles;

    public int width = 100;
    public int height = 100;
    public int offsetX = 0;
    public int offsetY = 0;

    [OnValueChanged("GenerateMap")]
    public float scale = 0.2f;
    private Dictionary<Vector3Int, int> tileHealth = new Dictionary<Vector3Int, int>();

    void Start()
    {
        GenerateMap();
    }

    [Button]
    void ClearMap()
    {
        tilemap.ClearAllTiles();
    }
    [Button]
    void GenerateMap()
    {
        // Обходим каждую ячейку на сетке, с учетом отступов
        for (int x = offsetX; x < offsetX + width; x++)
        {
            for (int y = offsetY; y < offsetY + height; y++)
            {
                // Применяем Perlin noise для получения значения между 0 и 1
                float perlinValue = Mathf.PerlinNoise(x * scale, y * scale);

                tilemap.SetTile(new Vector3Int(x, y, 0), groundTiles[Mathf.FloorToInt(perlinValue * groundTiles.Count)]);
            }
        }
    }
    // Рисуем область генерации в Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(offsetX + width / 2, offsetY + height / 2, 0), new Vector3(width, height, 1));
    }
}
