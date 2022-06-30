using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : Character
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    public override void TakeDamage(float damage, Character source)
    {
        if(source==this) return;
        Debug.Log("OOF");
        health -= damage;
        _audioSource.PlayOneShot(_audioClip);
        _audioSource.gameObject.transform.SetParent(GameManager.Instance.transform);
        Debug.Log(_audioSource.isPlaying);
        if (health <= 0)
        {
            GameManager.Score++;
            Destroy(gameObject);
        }
    }
}
