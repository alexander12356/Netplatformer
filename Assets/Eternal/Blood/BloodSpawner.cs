using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class BloodSpawner : MonoBehaviour {

    public Dictionary<string, GameObject> bloodSprites = new Dictionary<string, GameObject>();
    Transform bloodHolder;
    private void Start()
    {
        bloodHolder = new GameObject("blood_holder").transform;
        GameObject[] bloodArray = Resources.LoadAll<GameObject>("Effects/Blood");

        foreach (GameObject item in bloodArray){
            bloodSprites.Add(item.name, item);
        }
    }

    public void BloodSpawn(Vector3 attacker, Vector3 target, float targetHeight, float bloodTimelife){
        if (attacker.x < target.x){
            //SpawnRightBlood;
            GameObject _deltaBlood = Instantiate(bloodSprites["rightBlood"], new Vector3(target.x, target.y - targetHeight, target.z), Quaternion.identity);
            _deltaBlood.transform.SetParent(bloodHolder);
            StartCoroutine(BloodFade(bloodTimelife - .5f, _deltaBlood.GetComponent<SpriteRenderer>()));
            Destroy(_deltaBlood, bloodTimelife);
        }else{
            //SpawnLeftBlood;
            GameObject _deltaBlood = Instantiate(bloodSprites["leftBlood"], new Vector3(target.x, target.y - targetHeight, target.z), Quaternion.identity);
            _deltaBlood.transform.SetParent(bloodHolder);
            StartCoroutine(BloodFade(bloodTimelife - .5f, _deltaBlood.GetComponent<SpriteRenderer>()));
            Destroy(_deltaBlood, bloodTimelife);
        }
    }

    IEnumerator BloodFade(float duration, SpriteRenderer render){
        while (duration > 0)
        {
            yield return null;
            duration -= Time.deltaTime;
            render.color = Color.Lerp(render.color, new Color(render.color.r, render.color.g, render.color.b, 0), Time.deltaTime);
        }
    }

	bool side;

    public void BloodSpawnExample(){
        if (side){
            side = !side;
            Vector3 attacker = new Vector3(Random.Range(5, 10), Random.Range(0, 5), 0);
            Vector3 target = new Vector3(Random.Range(0, 5), Random.Range(0, 2), 0);
            BloodSpawn(attacker, target, 1, 5);
        }else{
            side = !side;
			Vector3 attacker = new Vector3(Random.Range(0, 5), Random.Range(0, 5), 0);
			Vector3 target = new Vector3(Random.Range(5, 15), Random.Range(0, 2), 0);
			BloodSpawn(attacker, target, 1, 5);
        }
    }

}
