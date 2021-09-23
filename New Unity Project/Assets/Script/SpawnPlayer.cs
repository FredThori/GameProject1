using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;

    private Transform Checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = Checkpoint.position;

        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject Player = Instantiate(player);

            player.transform.position = Checkpoint.position;
        }
    }

    public void SetPosition(Transform set)
    {
        Checkpoint = set;
    }
}
