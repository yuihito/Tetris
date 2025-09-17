using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    // 1マス用のPrefab（Blenderで作ったCubeを入れる）
    public GameObject blockPrefab;

    // 生成位置（空のオブジェクトを設定）
    public Transform spawnPoint;

    // 1マスの大きさ（調整用：BlenderのCubeが1なら1.0f、0.5にしたなら0.5f）
    private float unit = 1f;

    // enum（ミノの種類）
    public enum TetrominoType { I, O, T, L, J, S, Z }

    // 7バッグ（ランダム順）を保持するリスト
    private List<TetrominoType> bag = new List<TetrominoType>();

    // ==============================
    // 各ミノの形（相対座標）
    // ==============================
    private static readonly Vector2[][] shapes = new Vector2[][]
    {
        // Iミノ（一直線）
        new Vector2[] {
            new Vector2(-1.5f,0), new Vector2(-0.5f,0),
            new Vector2(0.5f,0), new Vector2(1.5f,0)
        },

        // Oミノ（四角）
        new Vector2[] {
            new Vector2(-0.5f,0.5f), new Vector2(0.5f,0.5f),
            new Vector2(-0.5f,-0.5f), new Vector2(0.5f,-0.5f)
        },

        // Tミノ（T字）
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(1.5f,0), new Vector2(0.5f,1)
        },

        // Lミノ（右向きのL）
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(1.5f,0), new Vector2(1.5f,1)
        },

        // Jミノ（左向きのL）
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(1.5f,0), new Vector2(-0.5f,1)
        },

        // Sミノ（右上がりのカーブ）
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(0.5f,1), new Vector2(1.5f,1)
        },

        // Zミノ（左上がりのカーブ）
        new Vector2[] {
            new Vector2(-0.5f,1), new Vector2(0.5f,1),
            new Vector2(0.5f,0), new Vector2(1.5f,0)
        }
    };

    // ミノごとの色
    private static readonly Color[] colors = {
        Color.cyan,   // I（水色）
        Color.yellow, // O（黄色）
        new Color(0.6f,0f,0.8f), // T（紫）
        new Color(1f,0.6f,0f),   // L（オレンジ）
        Color.blue,   // J（青）
        Color.green,  // S（緑）
        Color.red     // Z（赤）
    };

    void Start()
    {
        SpawnNext(); // 最初のミノを生成
    }

    // 次のミノをスポーンする
    public void SpawnNext()
    {
        TetrominoType next = GetNextFromBag();

        // 空の親オブジェクトを作る（これが1つのミノになる）
        GameObject tetromino = new GameObject("Tetromino_" + next.ToString());
        tetromino.transform.position = spawnPoint.position;

        // ブロックを並べる
        foreach (Vector2 pos in shapes[(int)next])
        {
            GameObject block = Instantiate(blockPrefab, tetromino.transform);
            block.transform.localPosition = new Vector3(pos.x * unit, pos.y * unit, 0);

            Renderer r = block.GetComponent<Renderer>();
            if (r != null)
            {
                r.material.color = colors[(int)next];
            }
        }
    }

    // 7バッグ方式で次のミノを取得
    private TetrominoType GetNextFromBag()
    {
        if (bag.Count == 0) RefillBag();
        TetrominoType t = bag[0];
        bag.RemoveAt(0);
        return t;
    }

    // バッグをシャッフルして補充
    private void RefillBag()
    {
        bag.Clear();
        foreach (TetrominoType t in System.Enum.GetValues(typeof(TetrominoType)))
        {
            bag.Add(t);
        }
        for (int i = 0; i < bag.Count; i++)
        {
            int j = Random.Range(i, bag.Count);
            (bag[i], bag[j]) = (bag[j], bag[i]);
        }
    }
}
