using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTutorial : MonoBehaviour
{
    // Common Stuff
    [SerializeField]
    private GameObject ObjectToSpawn;
    [SerializeField]
    private Transform SpawnPoint;

    // User Input
    [SerializeField]
    private KeyCode SpawnKey = KeyCode.Mouse0;
    [SerializeField]
    private KeyCode RapidSpawnKey = KeyCode.Mouse1;
    [SerializeField]
    private KeyCode CleanupKey = KeyCode.C;

    // Timers
    [SerializeField]
    private float InitialSpawnTime = 1f;
    [SerializeField]
    private float RepeatSpawnTime = 8f;

    // Start is called before the first frame update
    void Start()
    {
        string DelOBJ = ObjectToSpawn.name;
    }

    void Spawn(GameObject SpawnObject)
    {
        GameObject.Instantiate(SpawnObject, SpawnPoint);
    }

    void RapidSpawnMethod()
    {
        Spawn(ObjectToSpawn);
    }

    void DestroyGOs()
    {
        string DelOBJ = ObjectToSpawn.name + "(Clone)";
        Destroy(GameObject.Find(DelOBJ));
        Debug.Log("DestroyGO Called! Destroying = " + DelOBJ.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Spawn
        if (Input.GetKeyDown(SpawnKey))
        {
            Spawn(ObjectToSpawn);
        }

        // Rapid Spawn
        if (Input.GetKeyDown(RapidSpawnKey))
        {
            InvokeRepeating("RapidSpawnMethod", InitialSpawnTime * Time.deltaTime, RepeatSpawnTime * Time.deltaTime);
            Debug.Log("Pressed Rapidkey");
        }
        if (Input.GetKeyUp(RapidSpawnKey))
        {
            CancelInvoke();
        }

        // Cleanup
        if (Input.GetKey(CleanupKey))
        {
            DestroyGOs();
        }
    }
}
