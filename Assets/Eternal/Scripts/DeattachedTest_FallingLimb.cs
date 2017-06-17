using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class DeattachedTest_FallingLimb : MonoBehaviour
{
    [Range(0, 10)]
    public float FadeTime = 1f, timeUntilStart = 2f;

    Color color_a1 = new Color(1, 1, 1, 1);
    Color color_a0 = new Color(0, 0, 0, 0);

    public List<RigidLimb> rigidLimb = new List<RigidLimb>();

    [SerializeField]
    int currentLimb = 0;
    bool isActive = true;


    private void Start()
    {
        ListInit();

        currentLimb = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            LoseNextLimb();        
        }
    }

    void LoseNextLimb(){
        if (isActive){
            RigidLimb limb = rigidLimb[currentLimb];
            limb.limbPrefabRenderer.color = color_a1;
            limb.limbPrefab.SetActive(true);
            limb.limbPrefab.transform.position = limb.limbBone.transform.position;
            limb.limbPrefab.transform.rotation = Quaternion.identity;

            limb.limbPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, limb.detachForce), ForceMode2D.Impulse);

            limb.limbPrefab.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-limb.detachRotationForce, limb.detachRotationForce), ForceMode2D.Impulse);

            limb.limbBoneMesh.color = color_a0;

            limb.limbPrefab.GetComponent<DeattachedTest_Limb>().StartCoroutine(limb.limbPrefab.GetComponent<DeattachedTest_Limb>().FadeTo(1f, FadeTime, timeUntilStart));
            currentLimb++;
        }
        if (currentLimb >= rigidLimb.Count){
            isActive = false;
        }
    }

    void ListInit(){
        for (int i = 0; i < rigidLimb.Count; i++)
        {
            rigidLimb[i].limbPrefabRenderer = rigidLimb[i].limbPrefab.GetComponent<SpriteRenderer>();
            rigidLimb[i].limbPrefab.SetActive(false);

        }
    }
}