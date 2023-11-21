using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mycom.Target.Unity.Ads;

public class MYTAds : MonoBehaviour
{
    public static MYTAds S;

    private InterstitialAd interstitialAd;

    private void Awake()
    {
        S = this;
    }

    private InterstitialAd CreateInterstitialAd()
    {
        UInt32 slotId = 1236791;
#if UNITY_ANDROID
        slotId = 1236791;
#endif
        return new InterstitialAd(slotId);
    }

    public void InitAd()
    {
        interstitialAd = CreateInterstitialAd();

        interstitialAd.AdLoadCompleted += OnLoadCompleted;
        interstitialAd.AdDismissed += OnAdDismissed;
        interstitialAd.AdDisplayed += OnAdDisplayed;
        interstitialAd.AdVideoCompleted += OnAdVideoCompleted;
        interstitialAd.AdClicked += OnAdClicked;
        interstitialAd.AdLoadFailed += OnAdLoadFailed;

        interstitialAd.Load();
    }

    private void OnLoadCompleted(object sender, EventArgs e)
    {
        interstitialAd.Show();
    }

    private void OnAdDismissed(object sender, EventArgs e)
    {

    }

    private void OnAdDisplayed(object sender, EventArgs e)
    {

    }

    private void OnAdVideoCompleted(object sender, EventArgs e)
    {

    }

    private void OnAdClicked(object sender, EventArgs e)
    {

    }

    private void OnAdLoadFailed(object sender, ErrorEventArgs e)
    {
        Debug.Log("OnAdLoadFailed: " + e.Message);
    }
}
