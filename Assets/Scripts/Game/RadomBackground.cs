using System;
using UnityEngine;

public class RadomBackground : MonoBehaviour
{
    [SerializeField] private Material[] _backgrounds;
    [SerializeField] private Skybox _skybox;

    private Save _sv = new ();

    public void RandomBGInitialization()
    {
        _skybox.material = _backgrounds[UnityEngine.Random.Range(0, _backgrounds.Length)];
    }

    public void InitSave()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            _skybox.material = _sv._currentMaterial;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    public void OnApplicationPause(bool pause)
    {
        _sv._currentMaterial = _skybox.material;

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(_sv));
    }
#else
    public void OnApplicationQuit()
    {
        _sv._currentMaterial = _skybox.material;

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(_sv));
    }
#endif
}

[System.Serializable]
public class Save
{
    public Material _currentMaterial;
}
