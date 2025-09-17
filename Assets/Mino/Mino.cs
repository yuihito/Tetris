using UnityEngine;

public class Mino : MonoBehaviour
{
    // 1�����̃u���b�NPrefab�iBlender�ō�����L���[�u�j
    public GameObject blockPrefab;

    // �~�m�̎��
    public enum MinoType { I, O, T, L, J, S, Z }
    public MinoType type;

    void Start()
    {
        // �e�~�m�̌`�i���΍��W�Œ�`�j
        Vector2[][] shapes = new Vector2[][]
        {
            // I�~�m
            new Vector2[] {
                new Vector2(-1.5f,0), new Vector2(-0.5f,0),
                new Vector2(0.5f,0), new Vector2(1.5f,0)
            },
            // O�~�m
            new Vector2[] {
                new Vector2(-0.5f,0.5f), new Vector2(0.5f,0.5f),
                new Vector2(-0.5f,-0.5f), new Vector2(0.5f,-0.5f)
            },
            // T�~�m
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(1.5f,0), new Vector2(0.5f,1)
            },
            // L�~�m
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(1.5f,0), new Vector2(1.5f,1)
            },
            // J�~�m
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(1.5f,0), new Vector2(-0.5f,1)
            },
            // S�~�m
            new Vector2[] {
                new Vector2(-0.5f,0), new Vector2(0.5f,0),
                new Vector2(0.5f,1), new Vector2(1.5f,1)
            },
            // Z�~�m
            new Vector2[] {
                new Vector2(-0.5f,1), new Vector2(0.5f,1),
                new Vector2(0.5f,0), new Vector2(1.5f,0)
            }
        };

        // �~�m���Ƃ̐F�i�W���e�g���X�z�F�j
        Color[] colors = {
            Color.cyan,                  // I�i���F�j
            Color.yellow,                // O�i���F�j
            new Color(0.6f, 0f, 0.8f),   // T�i���j
            new Color(1f, 0.6f, 0f),     // L�i�I�����W�j
            Color.blue,                  // J�i�j
            Color.green,                 // S�i�΁j
            Color.red                    // Z�i�ԁj
        };

        // �I�΂ꂽ�~�m�𐶐�
        foreach (Vector2 pos in shapes[(int)type])
        {
            GameObject block = Instantiate(blockPrefab, transform);
            block.transform.localPosition = new Vector3(pos.x, pos.y, 0);

            // �F��K�p�iPrefab��Renderer������O��j
            Renderer r = block.GetComponent<Renderer>();
            if (r != null)
            {
                r.material.color = colors[(int)type];
            }
        }
    }
}
