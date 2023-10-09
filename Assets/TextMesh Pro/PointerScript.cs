using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    [SerializeField]
    float distance = 5f;
    [SerializeField]
    GameObject dot;
    /*[SerializeField]
    VRInputModule inputModule;*/
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    private LayerMask layerMask;

    public static GameObject currentObject;
    int currentID;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLine();
    }

    public string WatsTheHit(){
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, distance, layerMask);

        for(int i = 0; i < hits.Length; i++){
            RaycastHit hit = hits[i]; 
            int id = hits[i].collider.gameObject.GetInstanceID();
            currentObject = hit.collider.gameObject;
            string name = currentObject.name;
            Debug.Log("Button");
            Debug.Log(name);
            return(name);
        }
        
        return(name);
    }

    void UpdateLine(){
        float targetLength = distance;

        RaycastHit hit = Create(targetLength);
        // if(hit.collider == dot.GetComponent<Collider>()){
        //     return;
        // }
        Vector3 endPosition = transform.position + (transform.forward * targetLength);

        if(hit.collider != null){
            endPosition = hit.point;
        }

        dot.transform.position = endPosition;

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }

    RaycastHit Create(float distance){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, distance);
        return hit;
    }
}


