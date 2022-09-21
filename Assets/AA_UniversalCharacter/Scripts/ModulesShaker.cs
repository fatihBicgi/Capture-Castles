/////////////////////////////////////////////
//// Codewart Game Assets 2021
//// ModulesShaker.cs
//// Description: Set or randomize elements of characters within or between our modular packages
//// License: Use or modify as you need
//// Contact: support@codewart.com
//// Unity Asset Store: https://assetstore.unity.com/publishers/49258
/////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModulesShaker : MonoBehaviour {

    [Header("Package details:")]
    [Space]
    public string package_mark = "AA";//Package unique mark
    public int first_set_number = 0; //Naked element
    public int last_set_number = 10; //Last number of preset

    [Space]
    public string set_numeration = "001"; //Preset numeration you want to apply

    [HideInInspector]
    public string[] Gender = new string[] {"Male","Female"};
    [HideInInspector]
    public int gender_idx = 0;

    [Space]

    [Header("Other modular packages:")]

    public string[] other_packages = new string[] { };

    [Space]

    [Space]

    [Header("Body elements:")]

    [Space]

    //Unisex elements
    public GameObject unisex_belt;
    public GameObject unisex_cape;
    public GameObject unisex_elbow_l;
    public GameObject unisex_elbow_r;
    public GameObject unisex_eyebrows;
    public GameObject unisex_knee_l;
    public GameObject unisex_knee_r;
    public GameObject unisex_pauldron_l;
    public GameObject unisex_pauldron_r;

    //Female elements
    public GameObject arm_f_l;
    public GameObject arm_f_r;
    public GameObject calf_f_l;
    public GameObject calf_f_r;
    public GameObject foot_f_l;
    public GameObject foot_f_r;
    public GameObject forearm_f_l;
    public GameObject forearm_f_r;
    public GameObject hair_f;
    public GameObject hand_f_l;
    public GameObject hand_f_r;
    public GameObject head_f;
    public GameObject legs_f;
    public GameObject torso_f;

    //Male elements
    public GameObject arm_m_l;
    public GameObject arm_m_r;
    public GameObject calf_m_l;
    public GameObject calf_m_r;
    public GameObject facial_hair;
    public GameObject foot_m_l;
    public GameObject foot_m_r;
    public GameObject forearm_m_l;
    public GameObject forearm_m_r;
    public GameObject hair_m;
    public GameObject hand_m_l;
    public GameObject hand_m_r;
    public GameObject head_m;
    public GameObject legs_m;
    public GameObject torso_m;


    public void SetAll(string numeration)
    {
        SetElement("Belt",numeration);
        SetElement("Cape", numeration);
        SetElement("Elbow_L", numeration);
        SetElement("Elbow_R", numeration);
        SetElement("Eyebrows", numeration);
        SetElement("Knee_L", numeration);
        SetElement("Knee_R", numeration);
        SetElement("Pauldron_L", numeration);
        SetElement("Pauldron_R", numeration);

        SetElement("Arm_"+ getGender()+"_L",numeration);
        SetElement("Arm_" + getGender() + "_R", numeration);
        SetElement("Calf_" + getGender() + "_L", numeration);
        SetElement("Calf_" + getGender() + "_R", numeration);
        if (getGender() == "M")
        {
            SetElement("Facial_Hair", numeration);
        }
        else {
            facial_hair.SetActive(false);
        }
        SetElement("Foot_" + getGender() + "_L", numeration);
        SetElement("Foot_" + getGender() + "_R", numeration);
        SetElement("Forearm_" + getGender() + "_L", numeration);
        SetElement("Forearm_" + getGender() + "_R", numeration);
        SetElement("Hair_" + getGender(), numeration);
        SetElement("Hand_" + getGender() + "_L", numeration);
        SetElement("Hand_" + getGender() + "_R", numeration);
        SetElement("Head_" + getGender(), numeration);
        SetElement("Legs_" + getGender(), numeration);
        SetElement("Torso_" + getGender(), numeration);

    }
    
    public void RandomizeAll()
    {
        SetElement("Belt", getRandomNumeration(),false,true);
        SetElement("Cape", getRandomNumeration(), false, true);
        SetElement("Elbow_L", getRandomNumeration(), false, true);
        SetElement("Elbow_R", getRandomNumeration(), false, true);
        SetElement("Eyebrows", getRandomNumeration(), false, true);
        SetElement("Knee_L", getRandomNumeration(), false, true);
        SetElement("Knee_R", getRandomNumeration(), false, true);
        SetElement("Pauldron_L", getRandomNumeration(), false, true);
        SetElement("Pauldron_R", getRandomNumeration(), false, true);

        SetElement("Arm_" + getGender() + "_L", getRandomNumeration(), false, true);
        SetElement("Arm_" + getGender() + "_R", getRandomNumeration(), false, true);
        SetElement("Calf_" + getGender() + "_L", getRandomNumeration(), false, true);
        SetElement("Calf_" + getGender() + "_R", getRandomNumeration(), false, true);
        if (getGender() == "M")
        {
            SetElement("Facial_Hair", getRandomNumeration(), false, true);
        }
        else
        {
            facial_hair.SetActive(false);
        }
        SetElement("Foot_" + getGender() + "_L", getRandomNumeration(), false, true);
        SetElement("Foot_" + getGender() + "_R", getRandomNumeration(), false, true);
        SetElement("Forearm_" + getGender() + "_L", getRandomNumeration(), false, true);
        SetElement("Forearm_" + getGender() + "_R", getRandomNumeration(), false, true);
        SetElement("Hair_" + getGender(), getRandomNumeration(), false, true);
        SetElement("Hand_" + getGender() + "_L", getRandomNumeration(), false, true);
        SetElement("Hand_" + getGender() + "_R", getRandomNumeration(), false, true);
        SetElement("Head_" + getGender(), getRandomNumeration(), false, true);
        SetElement("Legs_" + getGender(), getRandomNumeration(), false, true);
        SetElement("Torso_" + getGender(), getRandomNumeration(), false, true);

    }
    public void RandomizeAllOther()
    {
        if (other_packages.Length == 0)
        {
            Debug.LogError("No other package reference marks in section 'Other_packages'");
            return;
        }

        SetElement("Belt", getRandomNumeration(),true,false);
        SetElement("Cape", getRandomNumeration(),true, false);
        SetElement("Elbow_L", getRandomNumeration(), true, false);
        SetElement("Elbow_R", getRandomNumeration(), true, false);
        SetElement("Eyebrows", getRandomNumeration(), true, false);
        SetElement("Knee_L", getRandomNumeration(), true, false);
        SetElement("Knee_R", getRandomNumeration(), true, false);
        SetElement("Pauldron_L", getRandomNumeration(), true, false);
        SetElement("Pauldron_R", getRandomNumeration(), true, false);

        SetElement("Arm_" + getGender() + "_L", getRandomNumeration(), true, false);
        SetElement("Arm_" + getGender() + "_R", getRandomNumeration(), true, false);
        SetElement("Calf_" + getGender() + "_L", getRandomNumeration(), true, false);
        SetElement("Calf_" + getGender() + "_R", getRandomNumeration(), true, false);
        if (getGender() == "M")
        {
            SetElement("Facial_Hair", getRandomNumeration(),true, false);
        }
        else
        {
            facial_hair.SetActive(false);
        }
        SetElement("Foot_" + getGender() + "_L", getRandomNumeration(), true, false);
        SetElement("Foot_" + getGender() + "_R", getRandomNumeration(), true, false);
        SetElement("Forearm_" + getGender() + "_L", getRandomNumeration(), true, false);
        SetElement("Forearm_" + getGender() + "_R", getRandomNumeration(), true, false);
        SetElement("Hair_" + getGender(), getRandomNumeration(), true, false);
        SetElement("Hand_" + getGender() + "_L", getRandomNumeration(), true, false);
        SetElement("Hand_" + getGender() + "_R", getRandomNumeration(), true, false);
        SetElement("Head_" + getGender(), getRandomNumeration(), true, false);
        SetElement("Legs_" + getGender(), getRandomNumeration(), true, false);
        SetElement("Torso_" + getGender(), getRandomNumeration(), true, false);

    }
    public void SetElement(string element, string numeration, bool randomOtherPackages = false, bool randomSamePackage = false) {

        SkinnedMeshRenderer smr = null;
        string from_package = package_mark;
        bool random = false;

        if (randomOtherPackages == true || randomSamePackage == true)
        {
            random = true;
        }

        //Debug.Log("Set element: "+element+" "+numeration);

        //unisex
        if (element == "Belt")
        {
            smr = unisex_belt.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Cape")
        {
            smr = unisex_cape.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Elbow_L")
        {
            smr = unisex_elbow_l.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Elbow_R")
        {
            smr = unisex_elbow_r.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Eyebrows")
        {
            smr = unisex_eyebrows.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Knee_L")
        {
            smr = unisex_knee_l.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Knee_R")
        {
            smr = unisex_knee_r.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Pauldron_L")
        {
            smr = unisex_pauldron_l.GetComponent<SkinnedMeshRenderer>();
        }
        else if (element == "Pauldron_R")
        {
            smr = unisex_pauldron_r.GetComponent<SkinnedMeshRenderer>();
        }
        //female
        else if (element == "Arm_F_L")
        {
            smr = arm_f_l.GetComponent<SkinnedMeshRenderer>();
            arm_f_l.SetActive(true);
            arm_m_l.SetActive(false);
        }
        else if (element == "Arm_F_R")
        {
            smr = arm_f_r.GetComponent<SkinnedMeshRenderer>();
            arm_f_r.SetActive(true);
            arm_m_r.SetActive(false);
        }
        else if (element == "Calf_F_L")
        {
            smr = calf_f_l.GetComponent<SkinnedMeshRenderer>();
            calf_f_l.SetActive(true);
            calf_m_l.SetActive(false);
        }
        else if (element == "Calf_F_R")
        {
            smr = calf_f_r.GetComponent<SkinnedMeshRenderer>();
            calf_f_r.SetActive(true);
            calf_m_r.SetActive(false);
        }
        else if (element == "Foot_F_L")
        {
            smr = foot_f_l.GetComponent<SkinnedMeshRenderer>();
            foot_f_l.SetActive(true);
            foot_m_l.SetActive(false);
        }
        else if (element == "Foot_F_R")
        {
            smr = foot_f_r.GetComponent<SkinnedMeshRenderer>();
            foot_f_r.SetActive(true);
            foot_m_r.SetActive(false);
        }
        else if (element == "Forearm_F_L")
        {
            smr = forearm_f_l.GetComponent<SkinnedMeshRenderer>();
            forearm_f_l.SetActive(true);
            forearm_m_l.SetActive(false);
        }
        else if (element == "Forearm_F_R")
        {
            smr = forearm_f_r.GetComponent<SkinnedMeshRenderer>();
            forearm_f_r.SetActive(true);
            forearm_m_r.SetActive(false);
        }
        else if (element == "Hair_F")
        {
            smr = hair_f.GetComponent<SkinnedMeshRenderer>();
            hair_f.SetActive(true);
            hair_m.SetActive(false);
        }
        else if (element == "Hand_F_L")
        {
            smr = hand_f_l.GetComponent<SkinnedMeshRenderer>();
            hand_f_l.SetActive(true);
            hand_m_l.SetActive(false);
        }
        else if (element == "Hand_F_R")
        {
            smr = hand_f_r.GetComponent<SkinnedMeshRenderer>();
            hand_f_r.SetActive(true);
            hand_m_r.SetActive(false);
        }
        else if (element == "Head_F")
        {
            smr = head_f.GetComponent<SkinnedMeshRenderer>();
            head_f.SetActive(true);
            head_m.SetActive(false);
        }
        else if (element == "Legs_F")
        {
            smr = legs_f.GetComponent<SkinnedMeshRenderer>();
            legs_f.SetActive(true);
            legs_m.SetActive(false);
        }
        else if (element == "Torso_F")
        {
            smr = torso_f.GetComponent<SkinnedMeshRenderer>();
            torso_f.SetActive(true);
            torso_m.SetActive(false);
        }
        //male
        else if (element == "Arm_M_L")
        {
            smr = arm_m_l.GetComponent<SkinnedMeshRenderer>();
            arm_f_l.SetActive(false);
            arm_m_l.SetActive(true);
        }
        else if (element == "Arm_M_R")
        {
            smr = arm_m_r.GetComponent<SkinnedMeshRenderer>();
            arm_f_r.SetActive(false);
            arm_m_r.SetActive(true);
        }
        else if (element == "Calf_M_L")
        {
            smr = calf_m_l.GetComponent<SkinnedMeshRenderer>();
            calf_f_l.SetActive(false);
            calf_m_l.SetActive(true);
        }
        else if (element == "Calf_M_R")
        {
            smr = calf_m_r.GetComponent<SkinnedMeshRenderer>();
            calf_f_r.SetActive(false);
            calf_m_r.SetActive(true);
        }
        else if (element == "Facial_Hair")
        {
            smr = facial_hair.GetComponent<SkinnedMeshRenderer>();
            facial_hair.SetActive(true);
        }
        else if (element == "Foot_M_L")
        {
            smr = foot_m_l.GetComponent<SkinnedMeshRenderer>();
            foot_f_l.SetActive(false);
            foot_m_l.SetActive(true);
        }
        else if (element == "Foot_M_R")
        {
            smr = foot_m_r.GetComponent<SkinnedMeshRenderer>();
            foot_f_r.SetActive(false);
            foot_m_r.SetActive(true);
        }
        else if (element == "Forearm_M_L")
        {
            smr = forearm_m_l.GetComponent<SkinnedMeshRenderer>();
            forearm_f_l.SetActive(false);
            forearm_m_l.SetActive(true);
        }
        else if (element == "Forearm_M_R")
        {
            smr = forearm_m_r.GetComponent<SkinnedMeshRenderer>();
            forearm_f_r.SetActive(false);
            forearm_m_r.SetActive(true);
        }
        else if (element == "Hair_M")
        {
            smr = hair_m.GetComponent<SkinnedMeshRenderer>();
            hair_f.SetActive(false);
            hair_m.SetActive(true);
        }
        else if (element == "Hand_M_L")
        {
            smr = hand_m_l.GetComponent<SkinnedMeshRenderer>();
            hand_f_l.SetActive(false);
            hand_m_l.SetActive(true);
        }
        else if (element == "Hand_M_R")
        {
            smr = hand_m_r.GetComponent<SkinnedMeshRenderer>();
            hand_f_r.SetActive(false);
            hand_m_r.SetActive(true);
        }
        else if (element == "Head_M")
        {
            smr = head_m.GetComponent<SkinnedMeshRenderer>();
            head_f.SetActive(false);
            head_m.SetActive(true);
        }
        else if (element == "Legs_M")
        {
            smr = legs_m.GetComponent<SkinnedMeshRenderer>();
            legs_f.SetActive(false);
            legs_m.SetActive(true);
        }
        else if (element == "Torso_M")
        {
            smr = torso_m.GetComponent<SkinnedMeshRenderer>();
            torso_f.SetActive(false);
            torso_m.SetActive(true);
        }

        if (randomOtherPackages == true)
        {
            from_package = getRandomOtherPackage();
        }

        //smr_name_set_any = element + "_" + from_package + "_";
        //smr_name = smr_name_set_any + numeration;

        if (smr != null)
        {
            smr.sharedMesh = findMesh(element,from_package,numeration, random, randomOtherPackages, 0);
            //findMesh(smr_name,random,smr_name_set_any, randomOtherPackages, 0);
            if (smr.sharedMesh == null)
            {
                //Debug.LogError("Element: "+element+" Not found any");
                //element not found,deactivate branch if not unisex
                if (numeration != "000")
                {
                    smr.gameObject.SetActive(false);
                }
            }
            else {
                smr.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("SkinnedMeshRenderer Not found! Check game object assignment or make sure that element exist");
        }
    }
    private string getRandomOtherPackage()
    {
        string ret = "";
        int otherPackagesCount = other_packages.Length;
        int random = UnityEngine.Random.Range(0, otherPackagesCount);

        ret = other_packages[random];

        return ret;
    }
    private string getRandomNumeration()
    {
        string ret = "";
        int random = UnityEngine.Random.Range(first_set_number, last_set_number+1);
        if (random < 10)
        {
            ret = "00" + random.ToString();
        }
        else
        {
            ret = "0" + random.ToString();
        }
        //Debug.Log("Random number:"+ret);
        return ret;
    }
    private string getGender() {
        if (gender_idx == 0)
        {
            return "M";
        }
        else {
            return "F";
        }
    }
    private Mesh findMesh(string element, string from_package, string numeration, bool random, bool randomOtherPackages, int tries)
    {
        Mesh[] meshes = Resources.FindObjectsOfTypeAll<Mesh>();
        Mesh ret = null;

        string meshName = element + "_" + from_package + "_" + numeration;
        string newRandomNumeration = numeration;
        string newRandomPackage = from_package;
        int nextTry = tries + 1;

        for (int i = 0; i < meshes.Length; i++)
        {
            if (meshes[i].name == meshName)
            {
                //Debug.Log(meshes[i].name);
                ret = meshes[i];
                break;
            }
        }

        if (ret == null)
        {
            if (random == true)
            {
                //if (random == true && !element.Contains("Cape"))
                //Try to find another for a lottery, except "Cape", could be cool without it as well, 
                //if want so just change above condition;) You can exclude other parts in here analogically

                if (tries < 100)//to avoid infinity loop in case of wrong range or no elements
                {
                    newRandomNumeration = getRandomNumeration();
                    newRandomPackage = from_package;
                    if (randomOtherPackages == true)
                    {
                        newRandomPackage = getRandomOtherPackage();
                    }
                    //Debug.LogWarning("Mesh " + element + "_" + from_package + " Try:" + nextTry);
                    ret = findMesh(element, newRandomPackage, newRandomNumeration, random, randomOtherPackages, nextTry);
                }
                else {
                    Debug.LogWarning("Mesh " + element + "_" + from_package + " not found any in random range! Make sure the object should exist or it has at least one instance on the stage");
                }
            }
            else {
                Debug.LogWarning("Mesh " + meshName + " not found! Make sure the object should exist or target MESH collection (in case of random mixing between packages) has at least one instance on the stage");
            }
        }

        return ret;

    }
}
