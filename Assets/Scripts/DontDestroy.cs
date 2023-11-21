using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _adsCore;
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Audio").Length == 1 && _adsCore != null)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
