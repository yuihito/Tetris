using UnityEngine;

public class Mino : MonoBehaviour
{
    // 1つだけのブロックPrefab（Blenderで作ったキューブ）
    public GameObject blockPrefab;

    // ミノの種類
    public enum MinoType { I, O, T, L, J, S, Z }
    public MinoType type;

    void Start()
    {
        // 各ミノの形（相対座標で定義）
        Vector2[][] shapes = new Vector2[][]
        {
            // Iミノ
            new Vector2[] {
                new Vector2(-1.5f,0), new Vector2(-0.5f,0),
                new Vector2(0.5f,0), new Vector2(1.5f,0)
            },
            // Oミノ
            new Vector2[] {
                new Vector2(-0.5f,0.5f), new Vector2(0.5f,0.5f),
                new Vector2(-0.5f,-0.5f), new Vector2(0.5f,-0.5f)
            },
            // Tミノ
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(1.5f,0), new Vector2(0.5f,1)
            },
            // Lミノ
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(1.5f,0), new Vector2(1.5f,1)
            },
            // Jミノ
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(1.5f,0), new Vector2(-0.5f,1)
            },
            // Sミノ
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(0.5f,1), new Vector2(1.5f,1)
            },
            // Zミノ
            new Vector2[] {
                new Vector2(-0.5f,1), new Vector2(0.5f,1),
                new Vector2(0.5f,0), new Vector2(1.5f,0)
            }
        };

        // ミノごとの色（標準テトリス配色）
        Color[] colors = {
            Color.cyan,                  // I（水色）
            Color.yellow,                // O（黄色）
            new Color(0.6f, 0f, 0.8f),   // T（紫）
            new Color(1f, 0.6f, 0f),     // L（オレンジ）
            Color.blue,                  // J（青）
            Color.green,                 // S（緑）
            Color.red                    // Z（赤）
        };

        // 選ばれたミノを生成
        foreach (Vector2 pos in shapes[(int)type])
        {
            GameObject block = Instantiate(blockPrefab, transform);
            block.transform.localPosition = new Vector3(pos.x, pos.y, 0);

            // 色を適用（PrefabにRendererがある前提）
            Renderer r = block.GetComponent<Renderer>();
            if (r != null)
            {
                r.material.color = colors[(int)type];
            }
        }
    }
}
