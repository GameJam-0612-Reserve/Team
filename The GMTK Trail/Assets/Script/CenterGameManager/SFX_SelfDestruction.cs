using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_SelfDestruction : MonoBehaviour
{
    private float time;

    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        if (m_audioSource.loop==false)
        {
            StartCoroutine(DestroySelfInSec(m_audioSource.clip.length));
        }
    }

    IEnumerator DestroySelfInSec(float sec)
    {
        yield return new WaitForSeconds(sec + 1f);
        Destroy(this.gameObject);
    }
}
