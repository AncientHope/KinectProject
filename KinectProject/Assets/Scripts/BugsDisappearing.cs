using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BugsDisappearing : MonoBehaviour
{

    public GameObject[] bugs, particleEffects, backgound, faseHolder;
    public bool disappearing, waiting, videoPlaying, kinectActive, bugScaled;
    public int fase;

    public GameObject text, pointToAttach, MoveTo, kinectIcon, bugToZoom;

    public VideoClip videoClip;
    public VideoPlayer videoPlayer;

    public Camera sceneCamera;

    public SpriteRenderer kinectIconRederer;

    void Start()
    {
        kinectIconRederer = kinectIcon.GetComponent<SpriteRenderer>();

        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameObject.Find("Main Camera");

        // VideoPlayer automatically targets the camera backplane when it is added
        // to a camera object, no need to change videoPlayer.targetCamera.
        videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();

        // Play on awake defaults to true. Set it to false to avoid the url set
        // below to auto-start playback since we're in Start().
        videoPlayer.playOnAwake = false;

        // By default, VideoPlayers added to a camera will use the far plane.
        // Let's target the near plane instead.
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;

        // This will cause our Scene to be visible through the video being played.
        //videoPlayer.targetCameraAlpha = 0.5F;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.clip = videoClip;

        // Skip the first 100 frames.
        //videoPlayer.frame = 100;

        // Restart from beginning when done.
        videoPlayer.isLooping = true;

        // Each time we reach the end, we slow down the playback by a factor of 10.
        //videoPlayer.loopPointReached += EndReached;

        // Start playback. This means the VideoPlayer may have to prepare (reserve
        // resources, pre-load a few frames, etc.). To better control the delays
        // associated with this preparation one can use videoPlayer.Prepare() along with
        // its prepareCompleted event.
        videoPlayer.Play();

        videoPlaying = true;
        fase = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (pointToAttach == null) {
            pointToAttach = GameObject.Find("HandRight");
            
        }

        if (pointToAttach != null)
        {
            MoveTo.transform.position = pointToAttach.transform.position;
        }


        if (fase == 0 && videoPlaying == false)
        {
            videoPlaying = true;
            videoPlayer.Play();

            backgound[0].SetActive(false);
            backgound[1].SetActive(false);

            faseHolder[0].SetActive(false);
            faseHolder[1].SetActive(false);

            text.SetActive(false);

        }
        else if (fase == 1)
        {
            videoPlayer.Stop();

            videoPlaying = false;
            backgound[0].SetActive(true);
            backgound[1].SetActive(false);

            faseHolder[0].SetActive(true);
            faseHolder[1].SetActive(false);

            text.SetActive(true);

            bugScaled = false;
            //sceneCamera.orthographicSize = 5000;

        }
        else if (fase == 2)
        {
           /* if (bugScaled == false)
            {
                bugToZoom.transform.localScale = new Vector2(50000, 50000);
                bugScaled = true;
            }

            if(bugToZoom.GetComponent<Renderer>().bounds.size.x > 400)
            {
                bugToZoom.transform.localScale *= 0.98f;

                if (bugToZoom.GetComponent<Renderer>().bounds.size.x < 400)
                {
                    bugToZoom.transform.localScale = new Vector2(400, 400);

                }
            }*/

            videoPlayer.Stop();

            videoPlaying = false;
            backgound[0].SetActive(false);
            backgound[1].SetActive(true);

            faseHolder[0].SetActive(false);
            faseHolder[1].SetActive(true);

            text.SetActive(false);

            //sceneCamera.orthographicSize = 2100;
        }
    }

    private void FixedUpdate()
    {
        if (disappearing == true && fase == 2 && waiting == false)
        {
            StartCoroutine("Disapear");
        }
    }

    IEnumerator Disapear()
    {
        waiting = true;

        for (int i = 0; i < bugs.Length; i++)
        {


            if (bugs[i].activeSelf)
            {
                bugs[i].SetActive(false);
                
                if(particleEffects[i] != null)
                particleEffects[i].SetActive(true);
                yield return new WaitForSeconds(1);
                waiting = false;
                break;
            }
            
        }

    }
}
