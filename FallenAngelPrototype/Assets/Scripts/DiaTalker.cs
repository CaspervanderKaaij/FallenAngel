using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]

public class DiaTalker : MonoBehaviour
{

    public Sprite[] talkers;
    Image img;
    public int curTalker;
    AudioSource source;
    public AudioClip[] talkSounds;


    void Start()
    {
        img = GetComponent<Image>();
		source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (img.sprite != talkers[curTalker])
        {
            img.sprite = talkers[curTalker];
            if (talkSounds[curTalker] != null)
            {
				source.Stop();
                source.clip = talkSounds[curTalker];
                source.Play();
            }
        }
    }
}
