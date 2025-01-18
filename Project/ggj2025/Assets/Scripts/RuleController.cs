using UnityEngine;
using System.Collections.Generic;



public class Rule
{
    public string reason;
    public string result;
}


public class RuleController : Singleton<RuleController>
{
    // public List<Rule> rules = new List<Rule>();


    [SerializeField]
    public List<string> states = new List<string>();


    public GameObject contentObj;

    public TextItem textItemPrefab;

    void Start()
    {
        AddState("气泡是圆的", "圆形的是气泡");
        AddState("气泡本身有单选框的意思", "单选框是气泡");
    }



    // public string GetResultByReason(string reason)
    // {
    //     foreach (var rule in rules)
    //     {
    //         if (rule.reason == reason)
    //         {
    //             return rule.result;
    //         }
    //     }
    //     return "";
    // }


    public bool isHasState(string state)
    {
        return states.Contains(state);
    }


    public void AddState(string reason, string result)
    {
        if (!states.Contains(result))
        {
            states.Add(result);
            TextItem textItem = Instantiate(textItemPrefab, contentObj.transform);
            string content = $"因为{reason}，所以{result}";
            textItem.Init(content);
        }
    }







    // public List<string> GetAllResult()
    // {

    //     List<string> newResults = new List<string>();
    //     foreach (var rule in rules)
    //     {
    //         if (states.Contains(rule.reason))
    //         {
    //             newResults.Add(rule.result);
    //         }
    //     }
    //     return newResults;
    // }
}

