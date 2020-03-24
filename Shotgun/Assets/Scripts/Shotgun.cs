using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{

    public LineRenderer lineRenderer;
    int framesShotgunDelay = 2;
    float shotLength = 10f;
    int amountOfShots = 10;
    float spreadDegrees = 15;

    public void Fire(){
        Vector3 pos = Input.mousePosition;
        pos.z = Camera.main.transform.position.y;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.y += transform.localScale.y / 2;
        pos -= transform.position;
        pos = pos.normalized;
        pos.x *= shotLength; pos.z *= shotLength;
        for (int i = 0; i < amountOfShots; i++)
        {
            Vector3 thisPos = Quaternion.Euler(0,Random.Range(-spreadDegrees, spreadDegrees),0) * pos;
            CastRay(thisPos);
            thisPos += transform.position;
            Vector3[] positions = {thisPos, transform.position};
            LineRenderer newLine = Instantiate(lineRenderer, Vector3.zero, Quaternion.Euler(0,0,0));
            newLine.SetPositions(positions);
            float width = Random.Range(0.02f, 0.09f);
            newLine.startWidth = width; newLine.endWidth = width;
            StartCoroutine(ShotAnimation(newLine));
        }
    }

    IEnumerator ShotAnimation(LineRenderer newLine){
        int showFrames = 0;
        while (showFrames < framesShotgunDelay){
            showFrames++;
            yield return null;
        }
        Destroy(newLine.gameObject);
    }

    void CastRay(Vector3 dir){
        Ray ray = new Ray(transform.position, dir);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, shotLength) && hitInfo.transform.gameObject.tag != "Player"){
            Destroy(hitInfo.transform.gameObject);
        }
    }
}
