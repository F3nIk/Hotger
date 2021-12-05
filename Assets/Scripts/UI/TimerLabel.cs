using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerLabel : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetTime(float seconds)
    {
        DateTime time = new DateTime().AddSeconds(seconds);

        _text.text = time.ToLongTimeString();

    }
}
