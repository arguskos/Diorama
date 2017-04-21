using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class InputBase : MonoBehaviour
{

    // Use this for initialization
    public GameObject Letter;
    public Material Mat;

    private GameObject UserSequence;
    private SoundManager _soundManager;
    public  List<int> _sequence = new List<int>();

    public GameObject MessegeText;
    public Text Score;
    public GameObject GameOverText;
    public Server Server;
    private int _currentLetter = 0;

    void Start()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        Generate();
        // obj.GetComponent<UISymbolEffects>()._isActive = true;

    }
    private void Generate()
    {
        if (UserSequence)
        {
            GameObject.Destroy(UserSequence);
        }
        UserSequence = new GameObject();
        for (int i = 0; i <= 3; i++)
        {
            var t = Instantiate(Letter, transform.position + new Vector3(0, 0, -0.24f + i), Quaternion.Euler(0, 90, 0));
            t.AddComponent<UISymbolEffects>();
            t.transform.parent = UserSequence.transform;
            t.layer = LayerMask.NameToLayer("UI");
            _sequence.Add(0);
        }
    }
    // Update is called once per frame
    private void OnButtonPress(int x, int y)
    {


        var obj = UserSequence.transform.GetChild(_currentLetter);
        _sequence[_currentLetter] = x * 4 + y;

        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(x * 0.25f, y * 0.25f));
    }

    private void PreviousLetter()
    {
        var obj = UserSequence.transform.GetChild(_currentLetter);
        _sequence[_currentLetter] = _sequence[_currentLetter] - 1;

        if (_sequence[_currentLetter] < 0)
        {
            _sequence[_currentLetter] = 15;
        }
        Debug.Log(_sequence[_currentLetter]);

        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(_sequence[_currentLetter] / 4) * 0.25f, _sequence[_currentLetter] % 4 * 0.25f));
    }
    private void NextLetter()
    {
        var obj = UserSequence.transform.GetChild(_currentLetter);
        _sequence[_currentLetter] = _sequence[_currentLetter] + 1;
        _sequence[_currentLetter] %= 16;

        obj.GetComponent<Renderer>().material = Mat;

        obj.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(Mathf.Floor(_sequence[_currentLetter] / 4) * 0.25f, _sequence[_currentLetter] % 4 * 0.25f));
    }

    public void EndGame()
    {
        GameOverText.SetActive(true);
        GameObject.Destroy( UserSequence);
        Server.LeaveRoom();
    }
    private void Check()
    {

        var l = _sequence;
        l.Sort();
        var d = DioramaObject.Symbols;
        d.Sort();
        if (l.SequenceEqual(d))
        {
            print("RIGHT");
            MessegeText.GetComponent<BlinkText>().TriggerText("Right", 1.0f, true);
            Score.text = "200";
            EndGame();

        }
        else
        {
            print("WRONG");
            MessegeText.GetComponent<BlinkText>().TriggerText("Wrong", 1.0f, true);

        }
        //bool right = true;
        //for (int i = 0; i < Cequencer.LettersInSequence.Count; i++)
        //{

        //    if (Cequencer.LettersInSequence[i].Key != _sequence[i])
        //    {
        //        right = false;
        //        break;

        //    }

        //}
        //if (right)
        //{
        //    print("RIGHT");
        //    _soundManager.PlaySound(SoundManager.Sound.Progress2);
        //    Cequencer.NextLevel();
        //    Cequencer.Generate();
        //    Generate();
        //    Right.enabled = true;
        //    Coutner.text = (int.Parse(Coutner.text) + 1).ToString();
        //}
        //else
        //{
        //    print("WRONG");
        //    _soundManager.PlaySound(SoundManager.Sound.Wrong);
        //    Wrong.enabled = true;

        //}
        //StartCoroutine(Hide());
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(1);
        //Right.enabled = false;
        //Wrong.enabled = false;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("extraBtn"))
        {
            Check();

        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("dipl1"))
        {
            NextLetter();
            _soundManager.PlaySound(SoundManager.Sound.Select);

        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("dipl2"))

        {
            PreviousLetter();
            _soundManager.PlaySound(SoundManager.Sound.Select);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("dipl3"))
        {
            //Decrease current letter
            _currentLetter--;
            if (_currentLetter < 0)
                _currentLetter = _sequence.Count - 1;

            //Make current letter scale relative to others
            var obj = UserSequence.transform.GetChild(_currentLetter);
            obj.GetComponent<UISymbolEffects>()._isActive = true;
            for (int i = 0; i < _sequence.Count; i++)
            {
                if (i != _currentLetter)
                {
                   UserSequence.transform.GetChild(i).GetComponent<UISymbolEffects>()._isActive = false;
                }

            }

        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("dipl4"))
        {
            //Decrease current letter
            _currentLetter++;
            _currentLetter %= _sequence.Count;

            //Make current letter scale relative to others
            var obj = UserSequence.transform.GetChild(_currentLetter);
            obj.GetComponent<UISymbolEffects>()._isActive = true;
            for (int i = 0; i < _sequence.Count; i++)
            {
                if (i != _currentLetter)
                {
                 UserSequence.transform.GetChild(i).GetComponent<UISymbolEffects>()._isActive = false;
                }

            }

        }

    }
}
