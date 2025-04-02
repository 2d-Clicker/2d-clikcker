using UnityEngine;

public class HandleAttack : MonoBehaviour
{
    public ParticleSystem clickParticle;
    public AudioClip clickAudio;
    [Range(0f, 1f)] public float clickAudioVolume = 0.5f;

    public void OnAttack()
    {
        if (clickParticle != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ParticleSystem particle = Instantiate(clickParticle, mousePos, Quaternion.Euler(180f, 0f, 0f));
            particle.Play();

            float lifetime = particle.main.startLifetime.constant;
            Destroy(particle.gameObject, lifetime);
        }

        if (clickAudio != null)
        {
            AudioSource.PlayClipAtPoint(clickAudio, Camera.main.transform.position, clickAudioVolume);
        }
    }
}