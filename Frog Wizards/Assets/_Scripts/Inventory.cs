using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour {

    private int bellflowerCount;
    private int bluebellCount;
    private int flyAgaricCount;
    private int indigoMushroomCount;
    private int periwinkleCount;
    private TextMeshProUGUI bfText;
    private TextMeshProUGUI bbText;
    private TextMeshProUGUI faText;
    private TextMeshProUGUI imText;
    private TextMeshProUGUI pText;

    void Start()
    {
        bfText = GameObject.Find("BellflowerNum").GetComponent<TMPro.TextMeshProUGUI>();
        bbText = GameObject.Find("BluebellNum").GetComponent<TMPro.TextMeshProUGUI>();
        faText = GameObject.Find("FlyAgaricNum").GetComponent<TMPro.TextMeshProUGUI>();
        imText = GameObject.Find("IndigoMushNum").GetComponent<TMPro.TextMeshProUGUI>();
        pText = GameObject.Find("PeriwinkleNum").GetComponent<TMPro.TextMeshProUGUI>();
        // Load the inventory counts from PlayerPrefs
        bellflowerCount = PlayerPrefs.GetInt("BellflowerCount", 0);
        bluebellCount = PlayerPrefs.GetInt("BluebellCount", 0);
        flyAgaricCount = PlayerPrefs.GetInt("FlyAgaricCount", 0);
        indigoMushroomCount = PlayerPrefs.GetInt("IndigoMushroomCount", 0);
        periwinkleCount = PlayerPrefs.GetInt("PeriwinkleCount", 0);

        // Update the UI text elements
        UpdateUIText();
    }

    void UpdateUIText()
    {
        bfText.text = bellflowerCount.ToString();
        bbText.text = bluebellCount.ToString();
        faText.text = flyAgaricCount.ToString();
        imText.text = indigoMushroomCount.ToString();
        pText.text = periwinkleCount.ToString();
    }

    void SaveInventoryCounts()
    {
        // Save the inventory counts to PlayerPrefs
        PlayerPrefs.SetInt("BellflowerCount", bellflowerCount);
        PlayerPrefs.SetInt("BluebellCount", bluebellCount);
        PlayerPrefs.SetInt("FlyAgaricCount", flyAgaricCount);
        PlayerPrefs.SetInt("IndigoMushroomCount", indigoMushroomCount);
        PlayerPrefs.SetInt("PeriwinkleCount", periwinkleCount);

        // Save the PlayerPrefs data
        PlayerPrefs.Save();
    }

    public void addItem(GameObject collectible)
    {
        switch (collectible.tag)
        {
            case "Bellflower":
                bellflowerCount++;
                break;
            case "Bluebell":
                bluebellCount++;
                break;
            case "FlyAgaric":
                flyAgaricCount++;
                break;
            case "IndigoMushroom":
                indigoMushroomCount++;
                break;
            case "Periwinkle":
                periwinkleCount++;
                break;
            default:
                print("Unidentifiable collectible");
                break;
        }

        // Update the UI text elements
        UpdateUIText();

        // Save the inventory counts
        SaveInventoryCounts();
    }
    
}