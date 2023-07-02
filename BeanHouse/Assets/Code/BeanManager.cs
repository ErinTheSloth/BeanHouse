using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanManager : MonoBehaviour
{
    public GameObject miniBeanPrefab;
    public Dictionary<BeanController, GameObject> AllBeans = new();
    
    private int currentBeanID = 0;
    

    private void GenerateBeanStats(BeanController newBean)
    {
        //Bean ID
        currentBeanID++;
        newBean.SetBeanID(currentBeanID);
        
        //Bean Name
        TextAsset nameList = Resources.Load<TextAsset>("Names");
        string[] names = nameList.text.Split('\n');
        string randomName = names[Random.Range(0, names.Length)].Trim();
        newBean.SetBeanName(randomName);
        
        //Gender
        string gender = (Random.Range(0, 2) == 0) ? "male" : "female";
        newBean.SetBeanGender(gender);
        
        //Hobbies
        List<string> hobbies = new List<string>();
        TextAsset hobbyTextAsset = Resources.Load<TextAsset>("Hobbies");
        string[] hobbyLines = hobbyTextAsset.text.Split('\n');
        int hobbiesCount = Random.Range(2, 3 + 1);
        for (int i = 0; i < hobbiesCount; i++)
        {
            string randomHobby = hobbyLines[Random.Range(0, hobbyLines.Length)].Trim();
            hobbies.Add(randomHobby);
        }
        newBean.SetBeanHobbies(hobbies);
        
        newBean.RevealInfo();
    }

    private void HatchMiniBean()
    {
        GameObject newBeanObject = Instantiate(miniBeanPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BeanController newBeanController = newBeanObject.AddComponent<BeanController>();
        
        GenerateBeanStats(newBeanController);
        
        AllBeans.Add(newBeanController, newBeanObject);
    }

}
