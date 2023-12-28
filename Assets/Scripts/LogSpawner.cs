using System.Collections;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject logPrefab; // Префаб модели
    private float spawnInterval = 10f; // Интервал спауна в секундах

    void SpawnLog()
    {
        // Проверяем, есть ли бревно в точке спауна
        if (transform.childCount == 0)
        {
            // Спауним новое бревно
            GameObject newLogObject = Instantiate(logPrefab, transform.position, Quaternion.identity);
            Log newLog = newLogObject.GetComponent<Log>();

            if (newLog != null)
            {
                // Присваиваем адрес спавнера бревну
                newLog.originalSpawner = this;
            }

            // Делаем бревно дочерним к точке спауна
            newLogObject.transform.parent = transform;
        }
    }

    public void RemoveLog(GameObject logToRemove)
    {
        // Удаляем бревно из игры
        Destroy(logToRemove);

        // Запускаем снова процесс спауна через некоторое время
        StartCoroutine(SpawnLogAfterDelay());
    }

    IEnumerator SpawnLogAfterDelay()
    {
        yield return new WaitForSeconds(spawnInterval);
        SpawnLog();
    }
}
