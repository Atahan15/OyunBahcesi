
using UnityEngine;

public class PlatformScale : MonoBehaviour
{
    [SerializeField] float minScale = 0.3f;
    [SerializeField] float maxScale = 1f;
    [SerializeField] float speed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {

        float scale = Mathf.Lerp(minScale, maxScale, Mathf.PingPong(Time.time * speed, 1.0f));

        this.transform.localScale = new Vector3(scale, 0.7f, 1);


    }


    //    her minimum deðerde çalýþmýyor (minimum scalede scale'i manuel zorlayýp hýzý arttýrma)
    //private void HarmonicScale()
    //{
    //    scale = Mathf.PingPong(i * 0.06f, 1);
    //    if (i > 1000) i = 0;
    //    i += 0.1f;
    //    if (scale < 0.3) //min
    //    {
    //        i += 5;
    //        scale = 0.3f;
    //    }
    //    this.transform.localScale = new Vector3(db,1,1);
    //}
}
