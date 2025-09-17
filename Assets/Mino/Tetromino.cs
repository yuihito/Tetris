using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float fallDelay = 1.0f; // 自然落下の間隔
    private float fallTimer;

    void Update()
    {
        HandleInput();
        HandleAutoFall();
    }

    // 入力処理
    private void HandleInput()
    {
        // 左移動 (Aキー)
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }

        // 右移動 (Dキー)
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }

        // ソフトドロップ (Sキー)
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * 5f;
        }

        // ハードドロップ (Wキー)
        if (Input.GetKeyDown(KeyCode.W))
        {
            while (true) // 下に行けなくなるまで落とす予定（今は仮）
            {
                transform.position += Vector3.down;
                // TODO: 当たり判定を後で追加
                if (transform.position.y < -10) break;
            }
        }

        // 左回転 (Lキー)
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.Rotate(0, 0, 90);
        }

        // 右回転 (Pキー)
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(0, 0, -90);
        }

        // ホールド (Shiftキー)
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Hold feature (未実装)");
        }
    }

    // 自然落下処理
    private void HandleAutoFall()
    {
        fallTimer += Time.deltaTime;
        if (fallTimer >= fallDelay)
        {
            transform.position += Vector3.down;
            fallTimer = 0;
        }
    }
}
