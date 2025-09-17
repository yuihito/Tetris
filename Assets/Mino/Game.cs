using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public int width = 10;
    public int height = 20;

    // �O���b�h�i�e�}�X��Transform��ێ��j
    public Transform[,] grid;

    public Mino spawner;

    void Awake()
    {
        if (Instance == null) Instance = this;
        grid = new Transform[width, height];
    }

    // �O���b�h�����ǂ����`�F�b�N
    public bool IsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < width && (int)pos.y >= 0);
    }

    // �O���b�h�Ƀu���b�N��u��
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

    // ���W�𐮐��Ɋۂ߂�
    public Vector2 Round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }

    // ���̃~�m���o��
    public void SpawnNextTetromino()
    {
        spawner.SpawnNext();
    }
}
