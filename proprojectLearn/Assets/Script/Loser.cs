using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Text txtFinalPoint;
    [SerializeField] Button rePlay;
    void Start()
    {
        int finalPoint = PlayerPrefs.GetInt("Point", 0);
        txtFinalPoint.text = $"Final Point: {finalPoint}";
        // Gán sự kiện cho nút bấm
        if (rePlay != null)
        {
            rePlay.onClick.AddListener(BackToSampleScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BackToSampleScene()
    {
        SceneManager.LoadScene("SampleScene"); // Load lại scene chính
    }
}