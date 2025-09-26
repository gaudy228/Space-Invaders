using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float _mulPositionX;
    [SerializeField] private float _mulPositionY;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private Vector2 _offsetPos;
    [SerializeField] private Score _score;
    [SerializeField] private PlayerWin _win;
    [SerializeField] private PlayerHP _hp;
    public Enemy[,] GridEnemys { get; private set; }
    private void Awake()
    {
        GridEnemys = new Enemy[_width, _height];
        for (int y = 0; y < GridEnemys.GetLength(1); y++)
        {
            for (int x = 0; x < GridEnemys.GetLength(0); x++)
            {
                if (_enemyPrefabs[y] == null)
                {
                    Debug.LogError("error");
                    return;
                }
                Vector2 worldPos = new Vector2(_offsetPos.x + x * _mulPositionX, _offsetPos.y + y * _mulPositionY);
                Enemy enemy = Instantiate(_enemyPrefabs[y], worldPos, Quaternion.identity, transform);
                enemy.Init(_score, _win, _hp);
                GridEnemys[x, y] = enemy;
            }
        }
    }
}
