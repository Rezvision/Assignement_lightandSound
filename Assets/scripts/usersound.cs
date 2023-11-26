using System.Collections;
using UnityEngine;

public class usersound : MonoBehaviour
{
    private AudioSource damageSound;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        damageSound = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional logic here if needed
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlaying)
        {
            damageSound.pitch = Random.Range(0.5f, 1.5f);
            StartCoroutine(PlaySoundFor30Seconds());
        }
        else
        {
            Debug.Log("Not the player" + other.tag);
        }
    }

    private IEnumerator PlaySoundFor30Seconds()
    {
        isPlaying = true;
        damageSound.Play();

        yield return new WaitForSeconds(0.5f);

        damageSound.Stop();
        isPlaying = false;
    }
}
