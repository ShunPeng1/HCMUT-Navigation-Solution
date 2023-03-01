using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TimeTable 
{
    private int _semester;
    private int _year;
    private string _info;
    public List<SubjectInfo> subjectInfos;

    public TimeTable(int semester, int year, string info)
    {
        _semester = semester;
        _year = year;
        _info = info;
        
        DecodeInfo();
    }

    private void DecodeInfo()
    {
        Regex splitLinePattern = new Regex( @"\n" );

        string[] subjectStrings = splitLinePattern.Split(_info);

        Debug.Log("Num of subject "+ subjectStrings.Length);
        foreach (var subject in subjectStrings)
        {
            
        }
    }



}
