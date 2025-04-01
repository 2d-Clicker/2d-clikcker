using UnityEngine;

public class HandleAttack : MonoBehaviour
{
    public ParticleSystem clickParticle;

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
    }
}