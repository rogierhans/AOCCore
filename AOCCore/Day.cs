﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

class Day
{
    public string RootFolder = @"C:\Users\Rogier\Dropbox\AOC2\AOC2\InputFiles\";
    //   public string RootFolder = @"C:\Users\Rogier\source\repos\AOC\AOC2\InputFiles\";
    public void GetInput(string folder)
    {
        string name = "input.txt";
        string filename = folder + name;
        string filenameTest = folder + "test.txt";
        var testLines = File.ReadAllLines(filenameTest).ToList();
        var inputLines = File.ReadAllLines(filename).ToList();
        var sw = new Stopwatch();
        sw.Start();
        Console.WriteLine("---###Test###---");
        Main(testLines);
        Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        Console.WriteLine("---###Input###---");
        Main(inputLines);
    }

    public virtual void Main(List<string> inputLines)
    {
        throw new NotImplementedException();
    }


    public List<List<T>> Transpose<T>(List<List<T>> oldList)
    {
        List<List<T>> newlist = new List<List<T>>();

        for (int j = 0; j < oldList[0].Count; j++)
        {
            List<T> list = new List<T>();
            for (int i = 0; i < oldList.Count; i++)
            {
                list.Add(oldList[i][j]);
            }
            newlist.Add(list);
        }

        return newlist;
    }
    public List<List<T>> Parse2D<T>(List<string> lines, Func<string, T> func)
    {
        return lines.Select(line => line.ToCharArray().Select(x => func(x.ToString())).ToList()).ToList();
    }

    public List<List<string>> ClusterLines(List<string> lines)
    {
        List<List<string>> List = new List<List<string>>();

        var currentList = new List<string>();
        foreach (var line in lines)
        {
            if (line == "")
            {
                List.Add(currentList);
                currentList = new List<string>();
            }
            currentList.Add(line);
        }
        List.Add(currentList);
        return List;
    }

}
