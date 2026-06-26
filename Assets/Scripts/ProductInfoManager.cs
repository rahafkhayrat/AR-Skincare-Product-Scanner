using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using Vuforia; // سطر مهم جداً للـ Focus

[System.Serializable]
public class ProductData
{
    public string imageName;
    public string productName;
    public string details;
}

public class ProductInfoManager : MonoBehaviour
{
    public GameObject productPanel;
    public TextMeshProUGUI productNameText;
    public TextMeshProUGUI detailsText;
    public Button showDetailsButton;
    public GameObject detailsPanel;

    public List<ProductData> products = new List<ProductData>();

    void Start()
    {
        // مسحنا الأكواد اللي بتعمل Errors عشان نعتمد على إعدادات يونيتي الجاهزة
        productPanel.SetActive(false);
        detailsPanel.SetActive(false);

        if (showDetailsButton != null)
        {
            showDetailsButton.onClick.RemoveAllListeners();
            showDetailsButton.onClick.AddListener(OnShowDetails);
        }
    }
    // 🔥 بتتنادي من Vuforia لما الصورة تظهر (لازم تربطيها في الـ Default Observer EventHandler)
    public void OnTargetFound(string imageName)
    {
        Debug.Log("Target Found: " + imageName);
        productPanel.SetActive(true);

        // رجّع UI لو كان مستخبي
        productNameText.gameObject.SetActive(true);
        showDetailsButton.gameObject.SetActive(true);
        detailsPanel.SetActive(false);

        bool found = false;
        foreach (var product in products)
        {
            // بنستخدم Equals وعملنا Trim عشان لو فيه مسافات زيادة في الاسم ماتبوظش الـ Tracking
            if (product.imageName.Trim().Equals(imageName.Trim()))
            {
                productNameText.text = product.productName;
                detailsText.text = product.details;
                found = true;
                break;
            }
        }

        if (!found)
        {
            productNameText.text = "Unknown Product: " + imageName;
        }
    }

    // 🔴 لما الصورة تختفي
    public void OnTargetLost()
    {
        productPanel.SetActive(false);
        detailsPanel.SetActive(false);
    }

    // 🔘 لما المستخدم يدوس الزرار
    public void OnShowDetails()
    {
        productNameText.gameObject.SetActive(false);
        showDetailsButton.gameObject.SetActive(false);
        detailsPanel.SetActive(true);
    }
}