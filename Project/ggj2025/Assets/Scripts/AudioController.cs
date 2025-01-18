using UnityEngine;

/// <summary>
/// AudioController 类用于播放和控制音频。
/// </summary>
public class AudioController : Singleton<AudioController>
{

    public AudioClip laughClip;
    private AudioSource audioSource; // 音频源

    void Start()
    {
        // 初始化音频源
        audioSource = gameObject.AddComponent<AudioSource>();
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
