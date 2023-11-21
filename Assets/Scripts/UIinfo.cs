using UnityEngine;

public class UIinfo : MonoBehaviour
{
    public static UIinfo instance;

    [SerializeField]
    GameObject removeAdsBtn;


    private void Start()
    {
        instance = this;
        UpdateRemoveAdsButton();
    }

    public void UpdateRemoveAdsButton()
    {
        bool removeAds = PlayerPrefs.GetString("removeads") == "yes";
        removeAdsBtn.SetActive(!removeAds);
    }
}
