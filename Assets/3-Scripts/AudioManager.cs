using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")] 
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume;

    [Header("Damage SFX")] 
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume;
    
    static AudioManager instance;
    
    void Awake()
    {
        ManageSingelton();
    }

    void ManageSingelton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // void ManageSingelton()
    // {
    //     int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
    //     if (instanceCount > 1)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }
    public void PlayShootingSFX()
    {
        PlayAudioClip(shootingClip, shootingVolume);
    }

    public void PlayDamageSFX()
    {
        PlayAudioClip(damageClip, damageVolume);
    }
    
    void PlayAudioClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}
