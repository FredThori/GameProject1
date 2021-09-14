using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject Unit;
    public static int NumberPoints;

    [SerializeField]
    Transform[] Points = new Transform[NumberPoints];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.LogWarning("Spawning");
        for (int i = 1; i < NumberPoints; i++)
        {
            Debug.Log("Spawning");
            GameObject Enemy = Instantiate(Unit, Points[i]);
        }
    }
}
