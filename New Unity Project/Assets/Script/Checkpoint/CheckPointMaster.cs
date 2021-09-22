using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointMaster : MonoBehaviour
{
    // Start is called before the first frame update

    private int Level;

    private Transform Checkpoint;

    [SerializeField] private Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransform(Transform Set)
    {
        Checkpoint = Set;
    }

    public void SetLevel(int Number)
    {
        Level = Number;
    }

    public void Restart()
    {
        SceneManager.LoadScene(Level);
        player.transform.position = Checkpoint.position;

    }
}
