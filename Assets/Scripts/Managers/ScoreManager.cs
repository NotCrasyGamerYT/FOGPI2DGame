using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set;}
    public float score {get; private set;}
    public float multiplier { get; private set;}

    void awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {   
            Destroy(this);
            return;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {

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
