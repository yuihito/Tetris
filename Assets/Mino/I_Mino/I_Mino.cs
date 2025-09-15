using UnityEngine;

public class I_Mino : MonoBehaviour
{
    public GameObject MinoPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float spacing = 0;
        float blockSize = 1;
        float distance = blockSize + spacing;

        for (int i = 0; i < 4; i++)
        {
            GameObject block = Instantiate(MinoPrefab, transform);
            float x = (i - 1.5f) * distance;
            block.transform.localPosition = new Vector3(x, 0, 0);
                
        }
        
    }

}
