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
            Debug.Log("Hold feature (������)");
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

    // ����������
    private void TryMove(Vector3 direction)
    {
        transform.position += direction;

        if (!IsValidPosition())
        {
            transform.position -= direction;

            // ���ɓ����Ȃ��Ƃ� �� �O���b�h�ɌŒ�
            if (direction == Vector3.down)
            {
                Game.Instance.AddToGrid(transform);
                enabled = false; // ���̃~�m�̑���𖳌���
                Game.Instance.SpawnNextTetromino(); // ���𐶐�
            }
        }
    }

    // �n�[�h�h���b�v
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

    // �L���Ȉʒu���m�F
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
