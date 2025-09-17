using System.Collections.Generic;
using UnityEngine;

public class Mino : MonoBehaviour
{
    // 1�}�X�p��Prefab�iBlender�ō����Cube������j
    public GameObject blockPrefab;

    // �����ʒu�i��̃I�u�W�F�N�g��ݒ�j
    public Transform spawnPoint;

    // 1�}�X�̑傫���i�����p�FBlender��Cube��1�Ȃ�1.0f�A0.5�ɂ����Ȃ�0.5f�j
    private float unit = 1f;

    // enum�i�~�m�̎�ށj
    public enum TetrominoType { I, O, T, L, J, S, Z }

    // 7�o�b�O�i�����_�����j��ێ����郊�X�g
    private List<TetrominoType> bag = new List<TetrominoType>();

    // ==============================
    // �e�~�m�̌`�i���΍��W�j
    // ==============================
    private static readonly Vector2[][] shapes = new Vector2[][]
    {
        // I�~�m�i�꒼���j
        new Vector2[] {
            new Vector2(-1.5f,0), new Vector2(-0.5f,0),
            new Vector2(0.5f,0), new Vector2(1.5f,0)
        },

        // O�~�m�i�l�p�j
        new Vector2[] {
            new Vector2(-0.5f,0.5f), new Vector2(0.5f,0.5f),
            new Vector2(-0.5f,-0.5f), new Vector2(0.5f,-0.5f)
        },

        // T�~�m�iT���j
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(1.5f,0), new Vector2(0.5f,1)
        },

        // L�~�m�i�E������L�j
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(1.5f,0), new Vector2(1.5f,1)
        },

        // J�~�m�i��������L�j
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(1.5f,0), new Vector2(-0.5f,1)
        },

        // S�~�m�i�E�オ��̃J�[�u�j
        new Vector2[] {
            new Vector2(-0.5f,0), new Vector2(0.5f,0),
            new Vector2(0.5f,1), new Vector2(1.5f,1)
        },

        // Z�~�m�i���オ��̃J�[�u�j
        new Vector2[] {
            new Vector2(-0.5f,1), new Vector2(0.5f,1),
            new Vector2(0.5f,0), new Vector2(1.5f,0)
        }
    };

    // �~�m���Ƃ̐F
    private static readonly Color[] colors = {
        Color.cyan,   // I�i���F�j
        Color.yellow, // O�i���F�j
        new Color(0.6f,0f,0.8f), // T�i���j
        new Color(1f,0.6f,0f),   // L�i�I�����W�j
        Color.blue,   // J�i�j
        Color.green,  // S�i�΁j
        Color.red     // Z�i�ԁj
    };

    void Start()
    {
        SpawnNext(); // �ŏ��̃~�m�𐶐�
    }

    // ���̃~�m���X�|�[������
    public void SpawnNext()
    {
        TetrominoType next = GetNextFromBag();

        // ��̐e�I�u�W�F�N�g�����i���ꂪ1�̃~�m�ɂȂ�j
        GameObject tetromino = new GameObject("Tetromino_" + next.ToString());
        tetromino.transform.position = spawnPoint.position;

        // �u���b�N����ׂ�
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

    // 7�o�b�O�����Ŏ��̃~�m���擾
    private TetrominoType GetNextFromBag()
    {
        if (bag.Count == 0) RefillBag();
        TetrominoType t = bag[0];
        bag.RemoveAt(0);
        return t;
    }

    // �o�b�O���V���b�t�����ĕ�[
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
