using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour {

    private int bellflowerCount = 0;
    private int bluebellCount = 0;
    private int flyAgaricCount = 0;
    private int indigoMushroomCount = 0;
    private int periwinkleCount = 0;
    private TextMeshProUGUI bfText;
    private TextMeshProUGUI bbText;
    private TextMeshProUGUI faText;
    private TextMeshProUGUI imText;
    private TextMeshProUGUI pText;

    void Start(){
        bfText = GameObject.Find("BellflowerNum").GetComponent<TMPro.TextMeshProUGUI>();
        bbText = GameObject.Find("BluebellNum").GetComponent<TMPro.TextMeshProUGUI>();
        faText = GameObject.Find("FlyAgaricNum").GetComponent<TMPro.TextMeshProUGUI>();
        imText = GameObject.Find("IndigoMushNum").GetComponent<TMPro.TextMeshProUGUI>();
        pText = GameObject.Find("PeriwinkleNum").GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update(){
        bfText.text = bellflowerCount.ToString();
        bbText.text = bluebellCount.ToString();
        faText.text = flyAgaricCount.ToString();
        imText.text = indigoMushroomCount.ToString();
        pText.text = periwinkleCount.ToString();
    }
   public void addItem(GameObject collectible){
        switch(collectible.tag)
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
                print ("Unidentifiable collectible");
                break;
        }

   }
}