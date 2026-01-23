using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfigSO", menuName = "Scriptable Objects/WaveConfigSO")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemySpeed;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float enemySpanwVariance = 0.2f;
    [SerializeField] float minimumSpanwTime = 0.2f;

    public Transform GetFirstWavepoint()
    {
        return pathPrefab.GetChild(0);
    }
    public Transform[]  GetWavepoints()
    {
        Transform [] waypoints = new Transform[pathPrefab.childCount];

        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }
        return waypoints;
    }
    public float GetEnemySpeed()
    {
        return enemySpeed;
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public float GetRandomEnemySpanwTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - enemySpanwVariance,
            timeBetweenEnemySpawns + enemySpanwVariance);
        
        spawnTime = Mathf.Clamp(spawnTime, minimumSpanwTime, float.MaxValue);
        return spawnTime;
    }
}
