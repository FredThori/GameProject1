using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] int Level;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(Level);
    }
}
