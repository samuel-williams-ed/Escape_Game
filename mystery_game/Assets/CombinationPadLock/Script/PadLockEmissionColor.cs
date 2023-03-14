// Script by Marcelli Michele

using UnityEngine;

public class PadLockEmissionColor : MonoBehaviour
{
    TimeBlinking tb;

    private GameObject _myRuller;

    [HideInInspector]
    public bool _isSelect;

    //[SerializeField] private float _timeBlinking = 0.5f;

    private void Awake()
    {
        tb = FindObjectOfType<TimeBlinking>();
    }
    void Start()
    {
        _myRuller = gameObject;
    }


    public void BlinkingMaterial()
    {
        _myRuller.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        
        if (_isSelect)
        {
            _myRuller.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.clear, Color.yellow, Mathf.PingPong(Time.time, tb.blinkingTime)));
        }
        if (_isSelect == false)
        {
            _myRuller.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.clear);
        }

    }
}
