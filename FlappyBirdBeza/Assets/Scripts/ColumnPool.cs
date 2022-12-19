using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject columnPrefab;
    public int columPoolSize = 5;
    public float spawnRate = 3f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private GameObject[] columns;
    private int currentColumn = 0;

    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawned = 0f;

        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.Identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (columnMin, columnMax);
            columns [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYposition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
