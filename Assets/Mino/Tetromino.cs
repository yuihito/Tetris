using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float fallDelay = 1.0f;
    private float fallTimer;

    void Update()
    {
        HandleInput();
        HandleAutoFall();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) TryMove(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D)) TryMove(Vector3.right);

        if (Input.GetKey(KeyCode.S)) TryMove(Vector3.down);

        if (Input.GetKeyDown(KeyCode.W)) HardDrop();

        if (Input.GetKeyDown(KeyCode.L)) transform.Rotate(0, 0, 90);
        if (Input.GetKeyDown(KeyCode.P)) transform.Rotate(0, 0, -90);

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Hold feature (未実装)");
        }
    }

    private void HandleAutoFall()
    {
        fallTimer += Time.deltaTime;
        if (fallTimer >= fallDelay)
        {
            TryMove(Vector3.down);
            fallTimer = 0;
        }
    }

    // 動かす処理
    private void TryMove(Vector3 direction)
    {
        transform.position += direction;

        if (!IsValidPosition())
        {
            transform.position -= direction;

            // 下に動けないとき → グリッドに固定
            if (direction == Vector3.down)
            {
                Game.Instance.AddToGrid(transform);
                enabled = false; // このミノの操作を無効化
                Game.Instance.SpawnNextTetromino(); // 次を生成
            }
        }
    }

    // ハードドロップ
    private void HardDrop()
    {
        while (true)
        {
            transform.position += Vector3.down;
            if (!IsValidPosition())
            {
                transform.position -= Vector3.down;
                Game.Instance.AddToGrid(transform);
                enabled = false;
                Game.Instance.SpawnNextTetromino();
                break;
            }
        }
    }

    // 有効な位置か確認
    private bool IsValidPosition()
    {
        foreach (Transform block in transform)
        {
            Vector2 pos = Game.Instance.Round(block.position);

            if (!Game.Instance.IsInsideGrid(pos))
                return false;

            if (Game.Instance.grid[(int)pos.x, (int)pos.y] != null &&
                Game.Instance.grid[(int)pos.x, (int)pos.y].parent != transform)
                return false;
        }
        return true;
    }
}
