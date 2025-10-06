using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Звуки интерфейса")]
    public AudioClip buttonClickSound;
    public AudioClip mouseClickSound;
    public AudioClip backgroundMusic;

    [Header("Настройки громкости")]
    [Range(0f, 1f)] public float sfxVolume = 0.7f;
    [Range(0f, 1f)] public float musicVolume = 0.5f;

    private AudioSource sfxSource;
    private AudioSource musicSource;

    private static AudioManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.volume = musicVolume;

        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AttachButtonSounds();
    }

    void Start()
    {
        AttachButtonSounds();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayMouseClick();
        }
    }

    private void AttachButtonSounds()
    {
        Button[] buttons = FindObjectsOfType<Button>(true);
        foreach (Button btn in buttons)
        {
            btn.onClick.RemoveListener(PlayButtonClick);
            btn.onClick.AddListener(PlayButtonClick);
        }
    }

    public void PlayButtonClick()
    {
        if (buttonClickSound != null)
            sfxSource.PlayOneShot(buttonClickSound, sfxVolume);
    }

    public void PlayMouseClick()
    {
        if (mouseClickSound != null)
            sfxSource.PlayOneShot(mouseClickSound, sfxVolume);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        if (musicSource.clip == clip) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
