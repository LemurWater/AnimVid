using TMPro;
using UnityEngine;


public class SceneController : MonoBehaviour
{


    // Variables ------------------------------------------
    [SerializeField] private SceneType sceneType;
    [SerializeField] private string sceneName;
    [SerializeField] private byte sceneIndex;
    [SerializeField] private string sceneDescription;
    [SerializeField] private string sceneInfo;



    // References -----------------------------------------
    private TextMeshProUGUI labelName;



    // Functions ------------------------------------------
    void Start()
    {
        labelName = GameObject.Find("Scene Info")
            .GetComponent<TextMeshProUGUI>();


        SetSceneLabel();
    }

    void SetSceneLabel()
    {
        switch (sceneType)
        {
            case SceneType.System:
                labelName.color = Color.magenta;
                break;
            case SceneType.Develop:
                labelName.color = Color.red;
                break;
            case SceneType.Showcase:
                labelName.color = Color.green;
                break;
        }
        labelName.text =
            sceneIndex + ". " + sceneName
            + " - " + sceneDescription;
    }
}
