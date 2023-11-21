using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;

    public static Timer S;

    public GameObject mainCube;
    public Color defCol, col;
    private float _timeLeft = 0f;
    private Color lastCol;

    private void Awake()
    {
        S = this;
    }

    public IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }
    }

    private void Start()
    {
        lastCol = mainCube.GetComponent<Renderer>().material.color;
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        if (!mainCube.GetComponent<GameController>().lose)
        {
            if (_timeLeft < 0)
            {
                    mainCube.GetComponent<GameController>().lose = true;
            }
            if (_timeLeft < 2.5)
            {
                GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, col, Time.deltaTime);
            }
        }

        if (mainCube.GetComponent<Renderer>().material.color != lastCol)
        {
            lastCol = mainCube.GetComponent<Renderer>().material.color;
            _timeLeft = time;
            GetComponent<Image>().color = defCol;
        }
    }
}
