using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    [SerializeField] private Text txtFinalPoint;
    [SerializeField] private Button btnPlay;

    void Start()
    {
        int finalPoint = PlayerPrefs.GetInt("Point", 0);
        int highPoint = PlayerPrefs.GetInt("HighPoint", 0);

        Debug.Log($"Final Point: {finalPoint}, HighPoint: {highPoint}");

        if (finalPoint > highPoint)
        {
            PlayerPrefs.SetInt("HighPoint", finalPoint);
            PlayerPrefs.Save();
            txtFinalPoint.text = $"New Record: {finalPoint}";
        }
        else
        {
            txtFinalPoint.text = $"Final Point: {finalPoint}";
        }
        if (btnPlay != null)
        {
            btnPlay.onClick.AddListener(BackToSampleScene);
        }
    }


    public void BackToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}