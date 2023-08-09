using UnityEngine;

namespace UniSnake {
  public class GameConfig : MonoBehaviour {
    [Header("Map")]
    public Vector2Int mapDimensions = new(10, 10);
    public GameObject wallPrefab;
    public GameObject foodPrefab;

    [Header("Snake")]
    public float moveInterval = 0.5f;
    public GameObject snakeHeadPrefab;
    public GameObject snakeBodyPrefab;
  }
}