using UnityEngine;

public class MasterLevelInfo : MonoBehaviour
{
    public static int DataCount = 0;
    [SerializeField] GameObject DataDisplay;

    void Update()
    {
        DataDisplay.GetComponent<TMPro.TMP_Text>().text = "Data: " + DataCount;
    }
}
