using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameCntrll;

    [SerializeField] private bool _funcDone;
    [SerializeField] private int _advCount = 0;
    [SerializeField] private Color _aColor;
    [SerializeField] private float _rCol, _gCol, _bCol;
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject[] _blocks = new GameObject[4];
    [SerializeField] private Button _showAdBttn;
    [SerializeField] private GameObject _timer;

    public static bool isPaused;

    public GameObject colBlock;
    public Vector3[] positions;
    public GameObject pLost;
    public GameObject rLost;

    public int rand, count;
    public Text score;

    [HideInInspector] public bool next, lose;

    private void Awake()
    {
        gameCntrll = this;
    }

    private void Start()
    {
        Initialization();
    }

    private void Update()
    {
        if(lose && !_funcDone)
        {
            PlayerLose();
        }
            
        if (next && !lose)
        {
            NextColors();
        }
    }

    public void Initialization()
    {
        count = 0;
        next = false;
        lose = false;
        isPaused = false;
        rand = Random.Range(0, positions.Length);

        for (int i = 0; i < positions.Length; i++)
        {
            _blocks[i] = Instantiate(colBlock, positions[i], Quaternion.identity) as GameObject;
            if (rand == i)
                _block = _blocks[i];
        }
        _block.GetComponent<RandCol>().right = true;

        pLost.SetActive(false);
    }

    void NextColors()
    {
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GetComponent<AudioSource>().Play();
        }
        count++;
        score.text = count.ToString();
        _aColor = new Vector4(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1);
        GetComponent<Renderer>().material.color = _aColor;
        next = false;

        if (count < 5)
        {
            _rCol = 0.7f;
            _gCol = 0.7f;
            _bCol = 0.7f;
        }
        else if (count >= 5 && count < 15)
        {
            _rCol = 0.5f;
            _gCol = 0.5f;
            _bCol = 0.5f;
        }
        else if (count >= 15 && count < 20)
        {
            _rCol = 0.2f;
            _gCol = 0.2f;
            _bCol = 0.2f;
        }
        else if (count >= 20 && count < 25)
        {
            _rCol = 0.1f;
            _gCol = 0.1f;
            _bCol = 0.1f;
        }
        else if (count >= 25 && count < 30)
        {
            _rCol = 0.1f;
            _gCol = 0.0f;
            _bCol = 0.1f;
        }
        else if (count >= 30 && count < 40)
        {
            _rCol = 0.0f;
            _gCol = 0.1f;
            _bCol = 0.1f;
        }
        else if (count >= 40 && count < 50)
        {
            _rCol = 0.1f;
            _gCol = 0.1f;
            _bCol = 0.0f;
        }
        else if (count >= 50)
        {
            _rCol = 0.0f;
            _gCol = 0.15f;
            _bCol = 0.0f;
        }

        //Новые цвета для блоков
        rand = Random.Range(0, positions.Length);
        for (int i = 0; i < positions.Length; i++)
        {
            if(i == rand)
            {
                _blocks[i].GetComponent<Renderer>().material.color = _aColor;
            }
            else
            {
                float r = _aColor.r + Random.Range(0.1f, _rCol) > 1f ? 1f : _aColor.r + Random.Range(0.1f, _rCol);
                float g = _aColor.g + Random.Range(0.1f, _gCol) > 1f ? 1f : _aColor.g + Random.Range(0.1f, _gCol);
                float b = _aColor.b + Random.Range(0.1f, _bCol) > 1f ? 1f : _aColor.b + Random.Range(0.1f, _bCol);

                _blocks[i].GetComponent<Renderer>().material.color = new Vector4(r, g, b, _aColor.a);
            }
        }
    }

    void PlayerLose()
    {
        _funcDone = true;
        _advCount++;
        if (_advCount %4 == 0)
        {
                YandexAds.instance.ShowAd();
        }

        if (PlayerPrefs.GetInt("Score") < count)
            PlayerPrefs.SetInt("Score", count);

        pLost.SetActive(true);
        rLost.SetActive(false);
        _timer.GetComponent<Timer>().StopAllCoroutines();

        if (PlayerPrefs.GetString("Music") == "no")
        {
            pLost.GetComponent<AudioSource>().mute = true;
        }
    }
}
