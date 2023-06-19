using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct DataInformation
{
    
    public string email;
    public string password;
    public string id;

    public DataInformation(string t_email, string t_password, string t_id)
    {
        this.email = t_email;
        this.password = t_password;
        this.id = t_id;
    }
}
public class HashTable : MonoBehaviour
{

  //  public List<DataInformation> data = new();
    Dictionary<string, DataInformation> dictionaryData = new();

    public TMP_Text console;

    string email;
    string pass;
    string id;
    string emailCheck;
    string PassCheck;
    
    public void EnterID(string a)
    {
        id = a;
    }
    public void EnterPassword(string b)
    {
        pass = b;
    }
    public void EnterEmail(string c)
    {
        email = c;
    }

    public void SaveData()
    {
        DataInformation structData = new DataInformation();
        structData.email = email;
        structData.password = pass;
        structData.id = id;
       // dictionaryData.Add(email, structData);

        try
        {
            dictionaryData.Add(email, structData);
            console.text = "Registro Exitoso";
        }
        catch(ArgumentException)
        {
            console.text = "Email ya existente";
            Debug.Log("Email ya existente");
        }
    }

    public void CheckEmail(string d)
    {
        emailCheck = d;
    }

    public void CheckPassword(string e)
    {
        PassCheck = e;
    }
    public void LogIn()
    {
        if (dictionaryData.TryGetValue(emailCheck, out DataInformation val))
        {
            if(val.password == PassCheck)
            {
                console.text = "Tu ID es: "+ " " + val.id;
            }
            else
            {
                console.text = "Contraseña incorrecta";
            }
        }
        else
        {
            console.text = "Email incorrecta";
        }
    }
}
