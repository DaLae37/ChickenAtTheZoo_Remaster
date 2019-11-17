using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{



    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collTag = collision.gameObject.tag;
        if (collTag.Equals("Player"))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "tutorial1":
                    SceneManager.LoadScene("tutorial2");
                    break;
                case "tutorial2":
                    SceneManager.LoadScene("stage1");
                    break;
                case "stage1":
                    SceneManager.LoadScene("stage2");
                    break;

            }

        }
    }

    public void ChangScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "tutorial1":
                SceneManager.LoadScene("tutorial2");
                break;
            case "tutorial2":
                SceneManager.LoadScene("stage1");
                break;
            case "stage1":
                SceneManager.LoadScene("stage2");
                break;

        }
    }
}
