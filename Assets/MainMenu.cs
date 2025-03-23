using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_Dropdown RowsDropdown;
    public TMP_Dropdown ColumnsDropdown;

    public TMP_Text vitory;
    public Button startButton;

    void Start()
    {
        //PlayerPrefs.DeleteKey("victory");
        if(PlayerPrefs.HasKey("victory")){
            vitory.text = "Player "+PlayerPrefs.GetInt("victory")+" Has Won !";
            
        }
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteKey("victory");
        int xValue = int.Parse(RowsDropdown.options[RowsDropdown.value].text);
        int yValue = int.Parse(ColumnsDropdown.options[ColumnsDropdown.value].text);
        // Save X and Y values from dropdowns
        PlayerPrefs.SetInt("rows", xValue);
        PlayerPrefs.SetInt("columns", yValue);
        PlayerPrefs.Save(); // Save the values permanently

        // Load the game scene
        SceneManager.LoadScene("GameScene");
    }
}
