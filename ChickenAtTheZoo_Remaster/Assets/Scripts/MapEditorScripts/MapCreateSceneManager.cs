using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Map
{
    public string mapName;
    public List<int> line1 = new List<int>();
    public List<int> line2 = new List<int>();
    public List<int> line3 = new List<int>();
    public List<int> line4 = new List<int>();
    public List<int> line5 = new List<int>();
    public List<int> line6 = new List<int>();
    public List<int> line7 = new List<int>();
    public List<int> line8 = new List<int>();
    public List<int> line9 = new List<int>();
    public List<int> line10 = new List<int>();

    public Map(string mapName, int[,] lists)
    {
        this.mapName = mapName;
        for (int i = 0; i < 25; i++)
        {
            line1.Add(lists[0, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line2.Add(lists[1, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line3.Add(lists[2, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line4.Add(lists[3, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line5.Add(lists[4, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line6.Add(lists[5, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line7.Add(lists[6, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line8.Add(lists[7, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line9.Add(lists[8, i]);
        }
        for (int i = 0; i < 25; i++)
        {
            line10.Add(lists[9, i]);
        }
    }

}
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
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                buttons[i, j] = buttonArray[i].transform.GetChild(j).GetComponent<Button>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
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

        buttons[y, x].image.sprite = sprites[currentSelect];
        mapArray[y, x] = currentSelect;
    }

    public void Accept()
    {
        string mapName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        Map map = new Map(mapName, mapArray);
        string json = JsonUtility.ToJson(map);
        reference.Child("maps").Child(mapName).SetRawJsonValueAsync(json);
        MapEditScene();
    }

    public void MapEditScene()
    {
        SceneManager.LoadScene("MapEditScene");
    }
}
