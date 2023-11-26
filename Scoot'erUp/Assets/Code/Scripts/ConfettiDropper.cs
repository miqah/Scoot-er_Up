using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiDropper : MonoBehaviour
{
    public GameObject[] confettiPrefabs;
    public int poolSizePerType = 10;
    public float fallTime = 3f;
    public float scale = 1.0f;
    public float spawnInterval = 0.001f;
    public float spawnRadius = 5f;

    private List<List<GameObject>> confettiPools = new List<List<GameObject>>();
    private Transform confettiParent;

    void Start()
    {
        confettiParent = new GameObject("ConfettiPool").transform;

        foreach (GameObject confettiPrefab in confettiPrefabs)
        {
            CreateConfettiPool(confettiPrefab);
        }

        StartCoroutine(SpawnConfettiRoutine());
    }

    void CreateConfettiPool(GameObject confettiPrefab)
    {
        List<GameObject> confettiPool = new List<GameObject>();
        for (int i = 0; i < poolSizePerType; i++)
        {
            GameObject confetti = Instantiate(confettiPrefab, confettiParent);
            confetti.SetActive(false);
            confettiPool.Add(confetti);
        }
        confettiPools.Add(confettiPool);
    }

    IEnumerator SpawnConfettiRoutine()
    {
        while (true)
        {
            for (int i = 0; i < confettiPools.Count; i++)
            {
                int confettiTypeIndex = i;
                GameObject confetti = GetNextAvailableConfetti(confettiTypeIndex);

                if (confetti != null)
                {
                    StartCoroutine(SpawnConfettiWithDelay(confetti));
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnConfettiWithDelay(GameObject confetti)
    {
        yield return new WaitForSeconds(Random.Range(0f, spawnInterval));

        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-spawnRadius, spawnRadius),
            transform.position.y,
            transform.position.z
        );

        SetConfettiProperties(confetti, spawnPosition);
        confetti.SetActive(true);

        StartCoroutine(ReturnConfettiToPoolAfterDelay(confetti, fallTime));
    }

    GameObject GetNextAvailableConfetti(int confettiTypeIndex)
    {
        List<GameObject> confettiPool = confettiPools[confettiTypeIndex];

        foreach (GameObject confetti in confettiPool)
        {
            if (!confetti.activeInHierarchy)
            {
                return confetti;
            }
        }
        return null;
    }

    void SetConfettiProperties(GameObject confetti, Vector3 spawnPosition)
    {
        confetti.transform.position = spawnPosition;
        confetti.transform.localScale = new Vector3(scale, scale, scale);
    }

    IEnumerator ReturnConfettiToPoolAfterDelay(GameObject confetti, float delay)
    {
        yield return new WaitForSeconds(delay);
        confetti.SetActive(false);
    }
}
