using UnityEngine;

/// <summary>
/// 音乐音符控制器，用于根据音乐的激烈程度打印值
/// </summary>
public class MusicNoteController : MonoBehaviour
{
    // 音频源
    private AudioSource audioSource;

    // 用于存储频谱数据的数组
    private float[] spectrumData = new float[256];

    [Header("音乐激烈程度")]
    private float intensity = 0;

    // 预计算的激烈程度数组
    [Header("预计算的激烈程度数组")]
    private float[] precomputedIntensities;
    private int currentIndex = 0;

    // 新增：用于存储每秒的平均激烈程度
    [Header("每秒平均激烈程度数组")]
    private float[] averageIntensities;

    // 计时器
    private float timer = 0f;

    [Header("平均激烈程度")]
    public float averageIntensity = 0;

    // 在游戏开始时调用一次
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("音频源未设置！");
            return;
        }

        // 预计算激烈程度
        precomputedIntensities = PrecomputeIntensities(audioSource.clip);

        // 计算每秒的平均激烈程度
        averageIntensities = ComputeAverageIntensities(precomputedIntensities, audioSource.clip.frequency);
    }

    // 每帧调用一次
    void Update()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            // 使用计时器来跟踪时间
            timer += Time.deltaTime;

            // 每秒打印一次平均激烈程度
            if (timer >= 1.0f)
            {
                // 计算当前秒的索引
                int currentSecondIndex = Mathf.FloorToInt(audioSource.time);

                // 确保索引在数组范围内
                if (currentSecondIndex < averageIntensities.Length)
                {
                    averageIntensity = averageIntensities[currentSecondIndex] * 15;

                    // 获取intensity的整数部分
                    int numberOfElements = Mathf.FloorToInt(averageIntensity);
                    print("生成音符" + numberOfElements);
                    // 生成相应数量的UI元素
                    for (int i = 0; i < numberOfElements; i++)
                    {
                        ItemController.Instance.SpawnUIElementAtRandomPosition();
                    }

                    Debug.Log("第 " + currentSecondIndex + " 秒的平均激烈程度: " + averageIntensity);
                }

                // 重置计时器
                timer = 0f;
            }
        }
    }

    /// <summary>
    /// 预计算音频剪辑的激烈程度
    /// </summary>
    /// <param name="clip">音频剪辑</param>
    /// <returns>激烈程度数组</returns>
    private float[] PrecomputeIntensities(AudioClip clip)
    {
        int sampleCount = clip.samples;
        int channels = clip.channels;
        float[] samples = new float[sampleCount * channels];
        clip.GetData(samples, 0);

        int segmentLength = 1024; // 每个片段的样本数
        int segmentCount = sampleCount / segmentLength;
        float[] intensities = new float[segmentCount];

        for (int i = 0; i < segmentCount; i++)
        {
            float sum = 0f;
            for (int j = 0; j < segmentLength; j++)
            {
                int index = i * segmentLength + j;
                sum += Mathf.Abs(samples[index]);
            }
            intensities[i] = sum / segmentLength;
        }

        return intensities;
    }

    /// <summary>
    /// 计算每秒的平均激烈程度
    /// </summary>
    /// <param name="intensities">预计算的激烈程度数组</param>
    /// <param name="frequency">音频采样率</param>
    /// <returns>每秒平均激烈程度数组</returns>
    private float[] ComputeAverageIntensities(float[] intensities, int frequency)
    {
        int samplesPerSecond = frequency / 1024;
        int secondsCount = intensities.Length / samplesPerSecond;
        float[] averages = new float[secondsCount];

        for (int i = 0; i < secondsCount; i++)
        {
            float sum = 0f;
            for (int j = 0; j < samplesPerSecond; j++)
            {
                int index = i * samplesPerSecond + j;
                if (index < intensities.Length)
                {
                    sum += intensities[index];
                }
            }
            averages[i] = sum / samplesPerSecond;
        }

        return averages;
    }
}
