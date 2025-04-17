using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set;}
    public float score { get; private set;}
    public float multiplier { get; private set;}
    public UnityEvent<ScoreInfo> updateScore;
    void Awake () 
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            //called on next scene load
            //instance.score = 0;
            Destroy(this);
            return;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehavior
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoints(float _amount, Vector3? _location = null)
    {
        score += _amount;

        
        updateScore.Invoke(new ScoreInfo(score, multiplier, _amount, _location));
    }

}

public class ScoreInfo
{
    public float score;
    public float multiplier;
    public float delta;
    public Vector3? location;

    public ScoreInfo(float _score, float _multiplier, float _delta, Vector3? _location = null) 
    {
        score = _score;
        multiplier = _multiplier;
        delta = _delta;
        location = _location;
    }
}
