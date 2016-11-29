using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapScript : MonoBehaviour {

    string url = "";

    public float lat =  24.917828f;
    public float lon = 67.097096f;
    LocationInfo li;
    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;
    public enum mapType { roadmap, satellite, hybrid, terrain };
    public mapType mapSelected;
    public int scale;

    private bool loadingMap = false;

    private IEnumerator mapCoroutine;


    IEnumerator GetGoogleMap(float lat, float lon)
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            +"&maptype=" + mapSelected +
            "&key=AIzaSyAe7r_gW3WsdO5iY7LP2sg_gRrMIkDyksI";
        loadingMap = true;
        WWW www = new WWW(url);
        yield return www;
        loadingMap = false;
        //Assign downloaded map texture to Canvas Image
        gameObject.GetComponent<RawImage>().texture = www.texture;
        StopCoroutine (mapCoroutine);

    }
    void Start()
    {
        mapCoroutine = GetGoogleMap (lat, lon);
        StartCoroutine(mapCoroutine);
    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.M)) {
            lat = 40.6786806f;
            lon = -073.8644250f;
            mapCoroutine = GetGoogleMap (lat, lon);
            StartCoroutine (mapCoroutine);
        }
    }
}
