using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioClip[] clips;
    AudioSource source;
    bool hasChangedMusic = false;
	public int normalMusic = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        source.volume = Mathf.Lerp(source.volume, 1, Time.unscaledDeltaTime / 5);
		SetBattleMusic();
    }

    public void ChangeMusic(int newClip, bool fadeIn)
    {
        source.Stop();
        source.clip = clips[newClip];
        source.Play();
        if (fadeIn == true)
        {
            source.volume = 0;
            source.time = Random.Range(0, clips[newClip].length);
        }
    }

    void SetBattleMusic()
    {
        if (FindObjectOfType<EnemySpawner>() == null && FindObjectOfType<EnemyBehaviour>() == null)
        {
            if (hasChangedMusic == false)
            {
                ChangeMusic(normalMusic, true);
                hasChangedMusic = true;
            }
        }
        else
        {
            hasChangedMusic = false;
        }
    }
}
