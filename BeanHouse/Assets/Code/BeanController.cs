using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanController : MonoBehaviour
{
    private int beanID;
    private string beanName;
    private string beanGender;
    private List<string> beanHobbies = new();

    public void SetBeanID(int id)
    {
        beanID = id;
    }

    public void SetBeanName(string name)
    {
        beanName = name;
    }

    public void SetBeanGender(string gender)
    {
        beanGender = gender;
    }

    public void SetBeanHobbies(List<string> hobbies)
    {
        beanHobbies = hobbies;
    }

    public void RevealInfo()
    {
        string pronoun = (beanGender == "male") ? "He" : "She";
        string possessivePronoun = (beanGender == "male") ? "His" : "Her";
        
        Debug.Log("A new bean called " + beanName + " has hatched!!");
        Debug.Log(pronoun + " enjoys the following hobbies:");

        foreach (string hobby in beanHobbies)
        {
            Debug.Log("- " + hobby);
        }
        
        Debug.Log("Make sure to care for " + beanName + " well!");
    }
}
