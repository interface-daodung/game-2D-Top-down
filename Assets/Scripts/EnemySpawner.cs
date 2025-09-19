using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject BossPrefab;
    [SerializeField] private Canvas EnegryBarCanvas;
    private AudioManager audioManager;
    private bool isPaused = false;

    public void spawnBoss()
    {
        isPaused = true;
        audioManager.PlayBossMusic();
        EnegryBarCanvas.gameObject.SetActive(false);
        Instantiate(BossPrefab, GetRandomOffscreenPosition(), Quaternion.identity);
    }
    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Wait until not paused
            while (isPaused)
            {
                yield return null;
            }
            yield return new WaitForSeconds(spawnInterval);
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = GetRandomOffscreenPosition();

            Instantiate(enemyPrefabs[randomIndex], spawnPos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomOffscreenPosition()
    {
        if (cam == null) return Vector3.zero;

        // Lấy giới hạn camera
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        float left = cam.transform.position.x - camWidth / 2f;
        float right = cam.transform.position.x + camWidth / 2f;
        float bottom = cam.transform.position.y - camHeight / 2f;
        float top = cam.transform.position.y + camHeight / 2f;

        // Tạo vùng bao ngoài camera
        float margin = 2f; // spawn cách rìa camera 1 đoạn
        float x, y;

        // Quyết định spawn bên ngoài theo X hay theo Y
        if (Random.value < 0.5f)
        {
            // Spawn ngoài theo X
            x = (Random.value < 0.5f) ? left - margin : right + margin;
            y = Random.Range(bottom - margin, top + margin);
        }
        else
        {
            // Spawn ngoài theo Y
            y = (Random.value < 0.5f) ? bottom - margin : top + margin;
            x = Random.Range(left - margin, right + margin);
        }

        return new Vector3(x, y, 0f);
    }


}
