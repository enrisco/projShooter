using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject ARCamera;
    [SerializeField] ShootingController player;
    [SerializeField] GameObject[] spawnObjects;
    [SerializeField] int min, max;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObject()
    {
        Vector3 pos = (Camera.main.transform.position + Camera.main.transform.forward * Random.Range(min, max)) - new Vector3(0, 4, 0);
        yield return new WaitForSeconds(3);

        for (int i = 0; i < spawnObjects.Length; i++)
        {
            GameObject enemy = Instantiate(spawnObjects[i], pos, Quaternion.identity);
            enemy.transform.Translate(Camera.main.transform.right * 2 * i);
            var e = enemy.GetComponent<EnemyScript>();
            e.camera = ARCamera;
            e.player = player;

        }

        StartCoroutine(SpawnObject());
    }
}
