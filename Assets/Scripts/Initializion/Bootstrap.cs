using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private YandexAds _yandexAds;
    [SerializeField] private RadomBackground _randomBackground;

    private void Awake()
    {
        _randomBackground.RandomBGInitialization();
        _yandexAds.Initialize();
    }
}
