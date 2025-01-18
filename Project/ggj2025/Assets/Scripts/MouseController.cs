using UnityEngine;
using System.Linq;
using System.Numerics; // 使用复数运算
using TMPro;

/// <summary>
/// 鼠标控制器，用于分析麦克风输入以判断吹气、吸气及其方向
/// </summary>
public class MouseController : MonoBehaviour
{
    public TMP_Text pitchText;
    public TMP_Text volumeText;

    public GameObject player;
    // 麦克风输入设备名称
    private string microphoneName;
    // 音频剪辑，用于存储麦克风输入
    private AudioClip microphoneClip;
    // 缓冲区，用于存储音频数据
    private float[] audioSamples = new float[256];
    // 玩家移动速度
    public float moveSpeed = 5.0f;

    public float threshold = 0.1f;

    public float pitchThreshold = 500.0f;
    public float volume = 0.0f;
    public float pitch = 0.0f;

    [Header("阈值")]
    public float lowerVolumeThreshold = 0.05f; // 下音量阈值
    [Header("音调阈值")]
    public float lowerPitchThreshold = 250.0f; // 低音调阈值

    private int speakCount = 0; // 记录说话次数
    private float speakTimer = 0.0f; // 计时器
    private bool isSpeaking = false; // 是否正在说话

    void Start()
    {
        // 获取默认麦克风设备
        microphoneName = Microphone.devices[0];
        // 开始录制麦克风输入
        microphoneClip = Microphone.Start(microphoneName, true, 1, 44100);
    }

    void Update()
    {
        // 实时监测麦克风音量
        MonitorMicrophoneVolume();
        // 实时监测麦克风音调
        MonitorMicrophonePitch();

        // 更新计时器
        speakTimer += Time.deltaTime;
        if (speakTimer >= 5.0f)
        {
            // 输出2秒内的说话次数
            Debug.Log("5秒内说话次数: " + speakCount);
            // 重置计数和计时器
            speakCount = 0;
            speakTimer = 0.0f;
        }
    }

    /// <summary>
    /// 监测麦克风音量并根据音量控制玩家移动
    /// </summary>
    private void MonitorMicrophoneVolume()
    {
        // 获取当前麦克风输入的音频数据
        microphoneClip.GetData(audioSamples, 0);
        // 计算音量
        volume = 0.0f;
        foreach (var sample in audioSamples)
        {
            volume += Mathf.Abs(sample);
        }
        volume /= audioSamples.Length;

        volumeText.text = "音量: " + volume.ToString("F2");

        // 检测说话状态，说话次数
        if (volume > threshold && !isSpeaking)
        {
            isSpeaking = true;
            speakCount++;
        }
        else if (volume < lowerVolumeThreshold && isSpeaking)
        {
            isSpeaking = false;
        }








        // 根据音量控制玩家上下移动
        if (volume > threshold) // 如果音量大于上阈值
        {
            // 向上移动玩家
            player.transform.Translate(UnityEngine.Vector3.up * moveSpeed * Time.deltaTime);
            print("向上移动");
        }
        else if (volume < lowerVolumeThreshold) // 如果音量小于下阈值
        {
            // 向下移动玩家
            player.transform.Translate(UnityEngine.Vector3.down * moveSpeed * Time.deltaTime);
            print("向下移动");
        }
    }

    /// <summary>
    /// 监测麦克风音调并根据音调控制玩家移动
    /// </summary>
    private void MonitorMicrophonePitch()
    {
        // 获取当前麦克风输入的音频数据
        microphoneClip.GetData(audioSamples, 0);

        // 计算FFT
        float[] spectrum = new float[audioSamples.Length];
        System.Array.Copy(audioSamples, spectrum, audioSamples.Length);
        FFT(spectrum);

        // 找到频率峰值
        float maxVal = spectrum.Max();
        int maxIndex = System.Array.IndexOf(spectrum, maxVal);

        // 计算音调
        pitch = maxIndex * (44100 / 2) / spectrum.Length;

        pitchText.text = "音调: " + pitch.ToString("F2");


        // 根据音调控制玩家左右移动
        if (pitch > pitchThreshold) // 如果音调大于高音调阈值
        {
            // 向右移动玩家
            player.transform.Translate(UnityEngine.Vector3.right * moveSpeed * Time.deltaTime);
            print("向右移动");
        }
        else if (pitch < lowerPitchThreshold) // 如果音调小于低音调阈值
        {
            // 向左移动玩家
            player.transform.Translate(UnityEngine.Vector3.left * moveSpeed * Time.deltaTime);
            print("向左移动");
        }
    }

    /// <summary>
    /// 快速傅里叶变换（FFT）算法
    /// </summary>
    private void FFT(float[] data)
    {
        int n = data.Length;
        Complex[] complexData = new Complex[n];

        // 将实数数据转换为复数
        for (int i = 0; i < n; i++)
        {
            complexData[i] = new Complex(data[i], 0);
        }

        // 执行FFT
        FFTRecursive(complexData);

        // 将结果转换回实数
        for (int i = 0; i < n; i++)
        {
            data[i] = (float)complexData[i].Magnitude;
        }
    }

    /// <summary>
    /// 递归实现FFT
    /// </summary>
    private void FFTRecursive(Complex[] data)
    {
        int n = data.Length;
        if (n <= 1) return;

        // 拆分数据为偶数和奇数部分
        Complex[] even = new Complex[n / 2];
        Complex[] odd = new Complex[n / 2];
        for (int i = 0; i < n / 2; i++)
        {
            even[i] = data[i * 2];
            odd[i] = data[i * 2 + 1];
        }

        // 递归调用FFT
        FFTRecursive(even);
        FFTRecursive(odd);

        // 合并结果
        for (int k = 0; k < n / 2; k++)
        {
            Complex t = Complex.Exp(-Complex.ImaginaryOne * 2 * Mathf.PI * k / n) * odd[k];
            data[k] = even[k] + t;
            data[k + n / 2] = even[k] - t;
        }
    }
}
