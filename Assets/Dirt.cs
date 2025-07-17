using UnityEngine;

public class Dirt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject prefabToDuplicate;
    public int copiesX = 5;
    public int copiesY = 5;
    public float spacingX = 2f;
    public float spacingY = 2f;
    public bool randomOffset = false;
    public float maxRandomOffset = 0.5f;
    
    void Start()
    {
        Duplicate();
    }

    public void Duplicate()
    {
        for (int i = 0; i < copiesY; i++)
        {
            for (int j = 0; j < copiesX; j++)
            {
                Generate(i, j);
            }
        }
    }

    public void Generate(int row, int col)
    {
        GameObject newCopy = Instantiate(prefabToDuplicate);
        newCopy.name = gameObject.name + "_Copy_" + row + col;
        Vector2 newPosition = transform.position;
        newPosition.x += spacingX * (col + 1);
        newPosition.y -= spacingY * (row + 1);
        if (randomOffset)
        {
            newPosition.x += Random.Range(-maxRandomOffset, maxRandomOffset);
            newPosition.y += Random.Range(-maxRandomOffset, maxRandomOffset);
        }
        newCopy.transform.position = newPosition;
        newCopy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

}
