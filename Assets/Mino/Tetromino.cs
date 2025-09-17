using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float fallDelay = 1.0f; // ���R�����̊Ԋu
    private float fallTimer;

    void Update()
    {
        HandleInput();
        HandleAutoFall();
    }

    // ���͏���
    private void HandleInput()
    {
        // ���ړ� (A�L�[)
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }

        // �E�ړ� (D�L�[)
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }

        // �\�t�g�h���b�v (S�L�[)
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * 5f;
        }

        // �n�[�h�h���b�v (W�L�[)
        if (Input.GetKeyDown(KeyCode.W))
        {
            while (true) // ���ɍs���Ȃ��Ȃ�܂ŗ��Ƃ��\��i���͉��j
            {
                transform.position += Vector3.down;
                // TODO: �����蔻�����Œǉ�
                if (transform.position.y < -10) break;
            }
        }

        // ����] (L�L�[)
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.Rotate(0, 0, 90);
        }

        // �E��] (P�L�[)
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.Rotate(0, 0, -90);
        }

        // �z�[���h (Shift�L�[)
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("Hold feature (������)");
        }
    }

    // ���R��������
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
