using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public int width = 10;
    public int height = 20;

    // グリッド（各マスにTransformを保持）
    public Transform[,] grid;

    public Mino spawner;

    void Awake()
    {
        if (Instance == null) Instance = this;
        grid = new Transform[width, height];
    }

    // グリッド内かどうかチェック
    public bool IsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    }

    // グリッドにブロックを置く
    public void AddToGrid(Transform tetromino)
    {
        foreach (Transform block in tetromino)
        {
            Vector2 pos = Round(block.position);
            if ((int)pos.y < height)
            {
                grid[(int)pos.x, (int)pos.y] = block;
            }
        }
    }

    // 座標を整数に丸める
    public Vector2 Round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    // 次のミノを出す
    public void SpawnNextTetromino()
    {
        spawner.SpawnNext();
    }
}
