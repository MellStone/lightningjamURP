using System.Collections;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject logPrefab; // ������ ������
    private float spawnInterval = 10f; // �������� ������ � ��������

    void SpawnLog()
    {
        // ���������, ���� �� ������ � ����� ������
        if (transform.childCount == 0)
        {
            // ������� ����� ������
            GameObject newLogObject = Instantiate(logPrefab, transform.position, Quaternion.identity);
            Log newLog = newLogObject.GetComponent<Log>();

            if (newLog != null)
            {
                // ����������� ����� �������� ������
                newLog.originalSpawner = this;
            }

            // ������ ������ �������� � ����� ������
            newLogObject.transform.parent = transform;
        }
    }

    public void RemoveLog(GameObject logToRemove)
    {
        // ������� ������ �� ����
        Destroy(logToRemove);

        // ��������� ����� ������� ������ ����� ��������� �����
        StartCoroutine(SpawnLogAfterDelay());
    }

    IEnumerator SpawnLogAfterDelay()
    {
        yield return new WaitForSeconds(spawnInterval);
        SpawnLog();
    }
}
