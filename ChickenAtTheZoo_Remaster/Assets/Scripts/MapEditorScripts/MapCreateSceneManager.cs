using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class MapCreateSceneManager : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[21];
    public int[,] mapArray = new int[10, 25];
    public GameObject[] buttonArray = new GameObject[10];
    private Button[,] buttons = new Button[10, 25];
    public GameObject[] mapList;
    int listIndex;
    int currentSelect;

    private DatabaseReference reference;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://chickenatthezoo.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        currentSelect = 0;
        listIndex = 0;
        mapList[listIndex].SetActive(true);
        for(int i=0; i<9; i++)
        {
            for(int j=0; j<25; j++)
            {
                buttons[i, j] = buttonArray[i].transform.GetChild(j).GetComponent<Button>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                MapEditScene();
            }
        }
    }

    public void NextList(int i)
    {
        mapList[listIndex].SetActive(false);
        listIndex += i;
        if (listIndex > 1)
            listIndex = 0;
        if (listIndex < 0)
            listIndex = 1;
        mapList[listIndex].SetActive(true);
    }

    public void ChangeCurrentSelect(int i)
    {
        currentSelect = i;
    }

    public void MapChange(string i)
    {
        string[] tmp = i.Split(',');
        int y = Convert.ToInt32(tmp[0]);
        int x = Convert.ToInt32(tmp[1]);
        
        buttons[y,x].image.sprite = sprites[currentSelect];
        mapArray[y, x] = currentSelect;
    }

    public void Accept()
    {
        string mapName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        //string json = JsonUtility.ToJson(map);
        //Debug.Log(json);
        //reference.Child("maps").Child(mapName).SetRawJsonValueAsync(json);
        MapEditScene();
    }

    public void MapEditScene()
    {
        SceneManager.LoadScene("MapEditScene");
    }
}
