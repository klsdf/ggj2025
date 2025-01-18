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

        // states.Add("气泡是圆的");
        // states.Add("苹果是气泡");
        AddState("气泡是圆的，而且苹果是圆的", "苹果是气泡");

        // rules = new List<Rule>(){
        //     new Rule() { reason = "气泡是圆的", result = "苹果是气泡" },
        //     new Rule() { reason = "苹果是气泡", result = "脸上的东西是气泡" },
        //     new Rule() { reason = "脸上的东西是气泡", result = "哭泣的脸是气泡" },
        //     new Rule() { reason = "哭泣的脸是气泡", result = "饥饿的脸是气泡" },
        //     // new Rule() { reason = "饥饿的脸是气泡", result = "饥饿的脸是气泡" }
        // };
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

