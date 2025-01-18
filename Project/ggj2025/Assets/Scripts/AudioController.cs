using UnityEngine;

/// <summary>
/// AudioController 类用于播放和控制音频。
/// </summary>
public class AudioController : Singleton<AudioController>
{

    public AudioClip laughClip;
    public AudioClip clickClip;
    public AudioClip clickClip2;
    public AudioClip bgmClip;

    private AudioSource audioSource; // 音频源

    private AudioSource clickSource;
    private AudioSource clickSource2;

    private AudioSource bgmSource;

    void Start()
    {
        // 初始化音频源
        audioSource = gameObject.AddComponent<AudioSource>();


        
        clickSource = gameObject.AddComponent<AudioSource>();
        clickSource.clip = clickClip;
        clickSource.loop = false;
        clickSource.volume = 0.5f;

        clickSource2 = gameObject.AddComponent<AudioSource>();
        clickSource2.clip = clickClip2;
        clickSource2.loop = false;
        clickSource2.volume = 1f;




        

        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }


    public void PlayClick()
    {
        if (clickClip != null)
        {
            // clickSource.clip = clickClip;
            clickSource.Play();
        }
    }

    public void PlayClick2()
    {
        if (clickClip2 != null)
        {
            clickSource2.Play();
        }
    }

    /// <summary>
    /// 播放音频剪辑
    /// </summary>
    /// <param name="clip">要播放的音频剪辑</param>
    public void PlayLaugh()
    {
        if (laughClip != null)
        {
            audioSource.clip = laughClip;
            audioSource.Play();
        }
    }

    /// <summary>
    /// 停止播放音频
    /// </summary>
    public void StopLaugh()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
