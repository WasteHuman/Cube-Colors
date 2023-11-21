using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    public void OnPurchaseCompleted(Product product)
    {
        switch (product.definition.id)
        {
            case "com.BIGYARGames.CubeColors.removeads":
                RemoveAds();
                break;
        }
    }

    private void RemoveAds()
    {
        PlayerPrefs.SetString("removeads", "yes");
        Debug.Log("Purchase: removeads");
        UIinfo.instance.UpdateRemoveAdsButton();
    }
}
