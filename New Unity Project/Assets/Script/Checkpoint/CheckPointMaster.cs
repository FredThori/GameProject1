using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointMaster : MonoBehaviour
{
    // Start is called before the first frame update

    private static int Level;

    private Vector3 Checkpoint;

    private GameObject player;

    private GameObject fakeScript;

    private static int restart;
    private static int playerCheck;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

       

    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError(Level);
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            
            player = GameObject.FindGameObjectWithTag("Player");
            
            if (playerCheck == 1)
            {
               
                player.transform.position = Checkpoint;
                playerCheck = 2;
            }

            if (restart == 1)
            {
                
                fakeScript = GameObject.FindGameObjectWithTag("Delete");

                Destroy(fakeScript);
            }
        }

        

        

    }

    public void SetTransform(Vector3 Set)
    {
        gameObject.tag = "Checkpoint";
        
        Checkpoint = Set;
    }

    public void SetLevel(int Number)
    {
        
        Level = Number;
    }

    public void Restart()
    {
        restart = 1;
        playerCheck = 1;

        SceneManager.LoadScene(Level);

    }
}
