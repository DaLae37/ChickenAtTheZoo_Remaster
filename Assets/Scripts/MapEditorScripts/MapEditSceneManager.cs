using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.UI;
using LitJson;
public class MapEditSceneManager : MonoBehaviour
{
    public GameObject panel;
    private DatabaseReference reference;
    private string s;
    private string mapData;
    private bool isLoadingSuccess;
    private bool isMap;
    public Text label;
    public Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        isLoadingSuccess = false;
        isMap = false;
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://chickenatthezoo.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child("maps").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                isMap = false;
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                s = snapshot.GetRawJsonValue().ToString();
                isMap = true;
            }
            isLoadingSuccess = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoadingSuccess)
        {
            isLoadingSuccess = false;

            JsonData getData = JsonMapper.ToObject(s);
            dropdown.options.Clear();

            for (int i = 0; i < getData.Count; i++)
            {
                if (i == 0)
                {
                    label.text = getData[i]["mapName"].ToString();
                }
                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = getData[i]["mapName"].ToString();
                dropdown.options.Add(option);
            }

            panel.SetActive(false);
        }
    }

    public void MapCreateScene()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("MapCreateScene");
    }

    public void MapMakeScene()
    {
        int val = dropdown.value;
        JsonData getData = JsonMapper.ToObject(s);
        StringBuilder sb = new StringBuilder();
        for (int j = 0; j < 25; j++)
        {
            sb.Append(getData[val]["line1"][j] + "@");
            sb.Append(getData[val]["line2"][j] + "@");
            sb.Append(getData[val]["line3"][j] + "@");
            sb.Append(getData[val]["line4"][j] + "@");
            sb.Append(getData[val]["line5"][j] + "@");
            sb.Append(getData[val]["line6"][j] + "@");
            sb.Append(getData[val]["line7"][j] + "@");
            sb.Append(getData[val]["line8"][j] + "@");
            sb.Append(getData[val]["line9"][j] + "@");
            sb.Append(getData[val]["line10"][j] + "@");
        }
        PlayerPrefs.SetString("MapMakeScene", sb.ToString());
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("MapMakeScene");
    }

    public void MainScene()
    {
        SoundManager.Instance.PlayEffectSound("buttonClick");
        SceneManager.LoadScene("mainMenuScene");
    }
}