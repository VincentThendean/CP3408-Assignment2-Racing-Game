using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetlist : MonoBehaviour
{
    public string purpose;
    public AudioClip[] audioLib;
    public AudioSource audioSource;

    int Iterator;
    int prevIndex;
    AudioClip track;
    double duration;
    bool fireTrigger;
    string gameState;

    private MeshRenderer meshRender;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        meshRender = this.GetComponent<MeshRenderer>();
        meshRender.enabled=false;

        if (purpose == "BGM"){
            gameState = "Game";
            Iterator = 1;
            }

        if (purpose == "SFX"){
            audioSource.Stop();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // For BGM loop
        
            if (purpose == "BGM"){
                if (!audioSource.isPlaying){
                    if (gameState == "End"){
                        audioSource.clip = audioLib[6];
                    }
                    else if (gameState == "Game"){
                        
                        if ((Iterator + 1) >= 5){
                            Iterator = 2;
                            prevIndex = 4; 
                        }else{
                            prevIndex = Iterator;
                            Iterator += 1;
                            }

                        track = audioLib[Iterator];
                        audioSource.clip = track;
                    }
                    audioSource.Play();
                }

                // replace with gamestate flag
                // if (Input.GetButtonDown("Fire2")){
                //     if (gameState == "Menu"){
                //         audioSource.Stop();
                //         gameState = "Game";
                //         Iterator = 1;

                //     }else if (gameState == "Game"){
                //         audioSource.Stop();
                //         gameState = "Menu";
                //     }
                 
                // }

                // // Replace with win flag
                // if (Input.GetButtonDown("Fire3")){
                //     audioSource.Stop();
                //     gameState = "End";
                // }

        
        
                }

        else if (purpose == "SFX"){
            // Replace with fire flag
            if (Input.GetButtonDown("Fire1")){
                
                fireTrigger = true;
                if (!audioSource.isPlaying){
                    if (fireTrigger){
                    audioSource.clip = audioLib[0];
                    audioSource.Play();
                    fireTrigger = false;
                    }
                }
            }

            // Replace with speed flag
            if (Input.GetButtonDown("Jump")){
                if (!audioSource.isPlaying){
                    audioSource.clip = audioLib[1];
                    audioSource.Play();
                    
                }
            }
            
        }           
    }
}
